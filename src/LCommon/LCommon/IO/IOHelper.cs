using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LCommon.Logging;
using LCommon.Utilities;
using LCommon.Extensions;

namespace LCommon.IO
{
    public class IOHelper
    {
        private readonly ILogger _logger;//Logger

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="loggerFactory"></param>
        public IOHelper(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.Create(GetType().FullName);
        }

        public void TryIOAction(string actionName, Func<string> getContext, Action action, int maxRetryTimes, bool continueRetryWhenRetryFailed = false, int retryInterval = 1000)
        {
            Ensure.NotNull(actionName, "actionName");
            Ensure.NotNull(getContext, "getContextInfo");
            Ensure.NotNull(action, "action");
            TryIOActionRecursivelyInternal(actionName, getContext, (x, y, z) => action(), 0, maxRetryTimes, continueRetryWhenRetryFailed, retryInterval);
        }

        public T TryIOFunc<T>(string funcName, Func<string> getContext, Func<T> func, int maxRetryTimes, bool continueRetryWhenRetryFailed = false, int retryInterval = 1000)
        {
            Ensure.NotNull(funcName, "funcName");
            Ensure.NotNull(getContext, "getContext");
            Ensure.NotNull(func, "func");
            return TryIOFuncRecursivelyInternal(funcName, getContext, (x, y, z) => func(), 0, maxRetryTimes, continueRetryWhenRetryFailed, retryInterval);
        }

        public void TryAsyncActionRecursively<TAsyncResult>(string asyncActionName, Func<Task<TAsyncResult>> asyncAction, Action<int> mainAction, Action<TAsyncResult> successAction, Func<string> getContextFunc, Action<string> failedAction, int retryTimes, bool continueRetryWhenRetryFailed = false, int maxRetryTimes = 3, int retryInterval = 1000) where TAsyncResult : AsyncTaskResult
        {
            var getContext = new Func<string>(() => {
                try
                {
                    return getContextFunc();
                }
                catch(Exception ex)
                {
                    _logger.Error("Failed to execute the getContextFunc", ex);
                    return null;
                }
            });

            var retryAction = new Action<int>(currentRetryTimes =>
            {
                try
                {
                    if (currentRetryTimes >= maxRetryTimes)
                    {
                        Task.Factory.StartDelayedTask(retryInterval, () => mainAction(currentRetryTimes + 1));
                    }else
                    {
                        mainAction(currentRetryTimes + 1);
                    }
                }catch(Exception ex)
                {
                    _logger.Error("Failed to execute the retryAction.", ex);
                }
            });

            var executeFailedAction = new Action<string>(errorMessage =>
            {
                try
                {
                    if (failedAction != null)
                        failedAction(errorMessage);
                }
                catch(Exception ex)
                {
                    _logger.Error(string.Format("Failed to execute the failedCallbackAction of asyncAction:{0}, contextInfo:{1}", asyncActionName, getContext()), ex);
                }
            });

            var processTaskException = new Action<Exception, int>((ex, currentRetryTimes) => { 
                if(ex is Exception)
                {
                    _logger.Error(string.Format("Async task '{0}' has io exception, contextInfo:{1}, current retryTimes:{2}, try to run the async task again.", asyncActionName, getContext(), currentRetryTimes), ex);
                    retryAction(retryTimes);
                }else
                {
                    _logger.Error(string.Format("Async task '{0}' has unknown exception, contextInfo:{1}, current retryTimes:{2}", asyncActionName, getContext(), currentRetryTimes), ex);
                    if (continueRetryWhenRetryFailed)
                        retryAction(retryTimes);
                    else
                        executeFailedAction(ex.Message);
                }
            });

            var completeAction = new Action<Task<TAsyncResult>>(t =>
            {
                try
                {
                    if (t.Exception != null)
                    {
                        processTaskException(t.Exception.InnerException, retryTimes);
                        return;
                    }
                    if (t.IsCanceled)
                    {
                        _logger.ErrorFormat("Async task '{0}' was cancelled, contextInfo:{1}, current retryTimes:{2}.", asyncActionName, getContext(), retryTimes);
                        executeFailedAction(string.Format("Async task '{0}' was cancelled.", asyncActionName));
                        return;
                    }
                    var result = t.Result;
                    if(result == null)
                    {
                        _logger.ErrorFormat("Async task '{0}' result is null, contextInfo:{1}, current retryTimes:{2}", asyncActionName, getContext(), retryTimes);

                        if(continueRetryWhenRetryFailed)
                        {
                            retryAction(retryTimes);
                        }
                        else
                        {
                            executeFailedAction(string.Format("Async task '{0}' result is null.", asyncActionName));
                        }

                        return;
                    }

                    if(result.Status == AsyncTaskStatus.Success)
                    {
                        if(successAction != null)
                            successAction(result);
                    }else if(result.Status == AsyncTaskStatus.IOException)
                    {
                        _logger.ErrorFormat("Async task '{0}' result status is io exception, contextInfo:{1}, current retryTimes:{2}, errorMsg:{3}, try to run the async task again.", asyncActionName, getContext(), retryTimes, result.ErrorMessage);
                        retryAction(retryTimes);
                    }else if(result.Status == AsyncTaskStatus.Failed)
                    {
                        _logger.ErrorFormat("Async task '{0}' failed, contextInfo:{1}, current retryTimes:{2}, errorMsg:{3}", asyncActionName, getContext(), retryTimes, result.ErrorMessage);
                        if(continueRetryWhenRetryFailed)
                        {
                            retryAction(retryTimes);
                        }else
                        {
                            executeFailedAction(result.ErrorMessage);
                        }
                    }
                }
                catch(Exception ex)
                {
                    _logger.Error("Failed to execute the completeAction.", ex);
                }
            });
        }

        #region private methods

        /// <summary>
        /// Try io action.
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="getContext"></param>
        /// <param name="action"></param>
        /// <param name="retryTimes"></param>
        /// <param name="maxRetryTimes"></param>
        /// <param name="continueRetryWhenRetryFailed"></param>
        /// <param name="retryInterval"></param>
        private void TryIOActionRecursivelyInternal(string actionName, Func<string> getContext, Action<string, Func<string>, int> action, int retryTimes, int maxRetryTimes, bool continueRetryWhenRetryFailed = false, int retryInterval = 1000)
        {
            try
            {
                action(actionName, getContext, retryTimes);
            }
            catch (IOException ex)
            {
                var errorMessage = string.Format("IOException raised when executing action '{0}', currentRetryTimes:{1}, maxRetryTimes:{2}, contextInfo:{3}", actionName, retryTimes, maxRetryTimes, getContext());

                _logger.Error(errorMessage, ex);
                if (retryTimes >= maxRetryTimes)
                {
                    if (!continueRetryWhenRetryFailed)
                    {
                        throw;
                    }
                    else
                    {
                        Thread.Sleep(retryInterval);
                    }
                }

                retryTimes++;
                TryIOActionRecursivelyInternal(actionName, getContext, action, retryTimes, maxRetryTimes);
            }
            catch (Exception ex)
            {
                var errorMessage = string.Format("Unknown exception raised when excuting action '{0}',currentRetryTimes:{1},maxRetryTimes:{2},contextInfo:{3}", actionName, retryTimes, maxRetryTimes, getContext());

                _logger.Error(errorMessage, ex);
                throw;
            }
        }
        
        /// <summary>
        /// Try do io func in generic .
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcName"></param>
        /// <param name="getContext"></param>
        /// <param name="func"></param>
        /// <param name="retryTimes"></param>
        /// <param name="maxRetryTimes"></param>
        /// <param name="continueRetryWhenRetryFailed"></param>
        /// <param name="retryInterval"></param>
        /// <returns></returns>
        private T TryIOFuncRecursivelyInternal<T>(string funcName, Func<string> getContext, Func<string, Func<string>, long, T> func, int retryTimes, int maxRetryTimes, bool continueRetryWhenRetryFailed = false, int retryInterval = 1000)
        {
            try
            {
                return func(funcName, getContext, retryTimes);
            }
            catch (IOException ex)
            {
                var errorMessage = string.Format("IOException raised when executing func '{0}', currentRetryTimes:{1}, maxRetryTimes:{2}, contextInfo:{3}", funcName, retryTimes, maxRetryTimes, getContext());

                _logger.Error(errorMessage, ex);
                if (retryTimes >= maxRetryTimes)
                {
                    if (!continueRetryWhenRetryFailed)
                    {
                        throw;
                    }
                    else
                    {
                        Thread.Sleep(retryInterval);
                    }
                }

                retryTimes++;
                return TryIOFuncRecursivelyInternal(funcName, getContext, func, retryTimes, maxRetryTimes, continueRetryWhenRetryFailed, retryInterval);
            }
            catch (Exception ex)
            {
                var errorMessage = string.Format("Unknown exception raised when excuting func '{0}',currentRetryTimes:{1},maxRetryTimes:{2},contextInfo:{3}", funcName, retryTimes, maxRetryTimes, getContext());

                _logger.Error(errorMessage, ex);
                throw;
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LCommon.Logging;
using LCommon.Utilities;

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

        public void TryIOAction(string actionName, Func<string> getContext, Action action, int maxRetryTimes, bool continueRetryFailed = false, int retryInterval = 1000)
        {
            Ensure.NotNull(actionName, "actionName");
            Ensure.NotNull(getContext, "getContextInfo");
            Ensure.NotNull(action, "action");


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
            catch(IOException ex)
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
        }

        #endregion
    }
}

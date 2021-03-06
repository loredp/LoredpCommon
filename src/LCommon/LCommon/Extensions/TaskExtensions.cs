﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace LCommon.Extensions
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Wait task.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="task"></param>
        /// <param name="timeoutMillis"></param>
        /// <returns></returns>
        public static TResult WaitResult<TResult>(this Task<TResult> task,int timeoutMillis)
        {
            if(task.Wait(timeoutMillis))
            {
                return task.Result;
            }

            return default(TResult);
        }

        /// <summary>
        /// After timeout.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="millisecondsDelay"></param>
        /// <returns></returns>
        //public static async Task TimeoutAfter(this Task task,int millisecondsDelay)
        //{
        //    var timeoutCancellationTokenSource = new CancellationTokenSource();
        //    var completeTask = await Task.WhenAny(task, Task.Delay(millisecondsDelay, timeoutCancellationTokenSource.Token));

        //    if(completeTask == task)
        //    {
        //        timeoutCancellationTokenSource.Cancel();
        //    }
        //    else
        //    {
        //        throw new TimeoutException("The operation has time out");
        //    }
        //}

        //public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, int millisecondsDelay)
        //{
        //    var timeoutCancellationTokenSource = new CancellationTokenSource();
        //    var completedTask = await Task.WhenAny(task, Task.Delay(millisecondsDelay, timeoutCancellationTokenSource.Token));
        //    if (completedTask == task)
        //    {
        //        timeoutCancellationTokenSource.Cancel();
        //        return task.Result;
        //    }
        //    else
        //    {
        //        throw new TimeoutException("The operation has timed out.");
        //    }
        //}
    }
}

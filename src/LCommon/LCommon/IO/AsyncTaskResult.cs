using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.IO
{
    public class AsyncTaskResult
    {
        public readonly static AsyncTaskResult Success = new AsyncTaskResult(AsyncTaskStatus.Success, null);

        /// <summary>
        /// Represents the async task result status.
        /// </summary>
        public AsyncTaskStatus Status { get; set; }

        /// <summary>
        /// Represents the error message if the async task is failed.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="erroMessage"></param>
        public AsyncTaskResult(AsyncTaskStatus status, string errorMessage)
        {
            Status = status;
            ErrorMessage = errorMessage;
        }
    }

    /// <summary>
    /// Represents an async task result status enum.
    /// </summary>
    public enum AsyncTaskStatus
    {
        Success,
        IOException,
        Failed,
    }
}

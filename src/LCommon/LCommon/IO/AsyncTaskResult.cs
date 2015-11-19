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
    /// Represents a generic async task result.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncTaskResult<T> : AsyncTaskResult
    {
        public T Data { get; private set; }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        public AsyncTaskResult(AsyncTaskStatus status)
            : this(status, null, default(T))
        {
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        public AsyncTaskResult(AsyncTaskStatus status, T data)
            : this(status, null, data)
        {
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        public AsyncTaskResult(AsyncTaskStatus status, string errorMessage)
            : this(status, errorMessage, default(T))
        {
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="errorMessage"></param>
        /// <param name="data"></param>
        public AsyncTaskResult(AsyncTaskStatus status, string errorMessage, T data)
            : base(status, errorMessage)
        {
            Data = data;
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

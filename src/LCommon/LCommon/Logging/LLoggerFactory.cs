using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Logging
{
    /// <summary>
    /// an implementation of ILoggerFactory.
    /// </summary>
    public class LLoggerFactory : ILoggerFactory
    {
        private static readonly LLogger Logger = new LLogger();//an logger.

        #region implmentation

        /// <summary>
        /// Create an logger instance by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ILogger Create(string name)
        {
            return Logger;
        }

        /// <summary>
        /// Create an logger instance by type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILogger Create(Type type)
        {
            return Logger;
        }

        #endregion
    }
}

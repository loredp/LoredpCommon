using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Logging
{
    /// <summary>
    /// Represents a logger factory <see cref="ILoggerFactory"/>.
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// Create a logger with the given logger name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ILogger Create(string name);

        /// <summary>
        /// Create a logger with the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ILogger Create(Type type);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Logging
{
    /// <summary>
    /// Represents a instance of logger.
    /// </summary>
    public class LLogger : ILogger
    {
        #region property
        
        public bool IsDebugEnabled
        {
            get { return false; }
        }

        #endregion

        #region methods

        public void Debug(object message)
        {
        }

        public void DebugFormat(string format, params object[] args)
        {
        }

        public void Debug(object message, Exception exception)
        {
        }

        public void Info(object message)
        {
        }

        public void InfoFormat(string format, params object[] args)
        {
        }

        public void Info(object message, Exception exception)
        {
        }

        public void Error(object message)
        {
        }

        public void ErrorFormat(string format, params object[] args)
        {
        }

        public void Error(object message, Exception exception)
        {
        }

        public void Warn(object message)
        {
        }

        public void WarnFormat(string format, params object[] args)
        {
        }

        public void Warn(object message, Exception exception)
        {
        }

        public void Fatal(object message)
        {
        }

        public void FatalFormat(string format, params object[] args)
        {
        }

        public void Fatal(object message, Exception exception)
        {
        }

        #endregion

    }
}

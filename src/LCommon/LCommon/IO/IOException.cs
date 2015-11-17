﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.IO
{
    [Serializable]
    public class IOException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public IOException() : base() { }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="message"></param>
        public IOException(string message) : base(message) { }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public IOException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public IOException(string message, params object[] args) : base(string.Format(message, args)) { }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <param name="args"></param>
        public IOException(string message, Exception innerException, params object[] args) : base(string.Format(message, args), innerException) { }
    }
}

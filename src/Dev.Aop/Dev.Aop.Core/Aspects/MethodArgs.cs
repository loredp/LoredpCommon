// 2015 Loredp Dev

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dev.Aop.Core.Aspects
{
    /// <summary>
    /// The method args.
    /// </summary>
    public abstract class MethodArgs : AdviceArgs
    {
        protected MethodArgs(object instance, MethodInfo methodInfo, Arguments arguments)
            : base(instance)
        {
            Method = methodInfo;
            Arguments = arguments;
        }

        /// <summary>
        /// Gets the method being executed.
        /// </summary>
        public MethodInfo Method { get; private set; }

        /// <summary>
        /// Gets the arguments with which the method has been invoked.
        /// </summary>
        public Arguments Arguments { get; private set; }

        /// <summary>
        /// Gets or sets the method return value.
        /// </summary>
        public object ReturnValue { get; set; }
    }
}

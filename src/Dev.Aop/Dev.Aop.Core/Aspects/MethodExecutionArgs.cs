// 2015 Loredp Dev

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dev.Aop.Core.Aspects
{
    /// <summary>
    /// Arguments of aspect which in executing for a method.
    /// </summary>
    public class MethodExecutionArgs : MethodArgs
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="methodInfo"></param>
        /// <param name="arguments"></param>
        public MethodExecutionArgs(object instance, MethodInfo methodInfo, Arguments arguments)
            : base(instance, methodInfo, arguments)
        { }

        /// <summary>
        /// Determines the control flow of the target method once the advice is exited.
        /// </summary>
        public FlowBehavior FlowBehavior { get; set; }

        /// <summary>
        /// Gets the exception currently flying.
        /// </summary>
        public Exception Exception { get; set; }
    }
}

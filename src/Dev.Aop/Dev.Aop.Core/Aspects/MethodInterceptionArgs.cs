// 2015 Loredp Dev

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dev.Aop.Core.Aspects
{
    /// <summary>
    ///  Abstract class for arguments of aspect which intercept a method.
    /// </summar
    public abstract class MethodInterceptionArgs : MethodArgs
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="arguments"></param>
        internal MethodInterceptionArgs(object instance, MethodInfo methodInfo, Arguments arguments)
            : base(instance, methodInfo, arguments)
        { }

        /// <summary>
        /// Proceeds with invocation of the method that has been intercepted by calling the next node in the chain of invocation,
        /// passing the current <see cref="Arguments"/> to that method
        /// and storing its return value into the property <see cref="MethodArgs.ReturnArgs"/>
        /// </summary>
        public abstract void Proceed();
    }
}

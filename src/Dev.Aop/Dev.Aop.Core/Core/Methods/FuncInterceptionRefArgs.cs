// 2015 Loredp Dev

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Dev.Aop.Core.Aspects;

namespace Dev.Aop.Core.Core.Methods
{
    /// <summary>
    /// Arguments of aspect which intercept a method with return value and parameters passed by reference.
    /// </summary>
    internal class FuncInterceptionRefArgs : MethodInterceptionArgs
    {
        private readonly Delegate _func;
        private readonly object[] _argsValues;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="argsValues"></param>
        /// <param name="func"></param>
        public FuncInterceptionRefArgs(object instance, MethodInfo method, object[] argsValues, Delegate func)
            : base(instance, method, new Arguments(argsValues))
        {
            _func = func;
            _argsValues = argsValues;
        }

        /// <summary>
        /// Proceeds with invocation of the method that has been intercepted by calling the next node in the chain of 
        /// passing the current <see cref="Arguments"/> to that method and storing its return value into the property ReturnValue.
        /// </summary>
        public override void Proceed()
        {
            ReturnValue = _func.DynamicInvoke(_argsValues);
        }
    }
}

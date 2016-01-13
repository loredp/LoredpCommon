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
    ///  Arguments of aspect which intercept a method without return value and parameters passed by reference.
    /// </summary>
    internal class ActionInterceptionRefArgs : MethodInterceptionArgs
    {
        private readonly Delegate _action;
        private readonly object[] _argsValues;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="method"></param>
        /// <param name="argsValues"></param>
        /// <param name="action"></param>
        public ActionInterceptionRefArgs(object instance, MethodInfo method, object[] argsValues, Delegate action)
            : base(instance, method, new Arguments(argsValues))
        {
            _action = action;
            _argsValues = argsValues;
        }

        /// <summary>
        /// Proceeds with invocation of the method that has been intercepted by calling the next node in the chain of invocation,
        /// passing the current <see cref="Arguments"/> to that method. 
        /// </summary>
        public override void Proceed()
        {
            _action.DynamicInvoke(_argsValues);
        }
    }
}

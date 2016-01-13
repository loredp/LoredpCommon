// 2015 Loredp Dev

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev.Aop.Core.IAspects;

namespace Dev.Aop.Core.Aspects
{
    /// <summary>
    /// Aspect that, when applied on a method, intercepts invocations of this method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class MethodInterceptionAspect : Aspect, IMethodAspect
    {
        /// <summary>
        /// Method invoked instead of the method to which the aspect has been applied.
        /// </summary>
        /// <param name="args">Method arguments including return value and all necessary info.</param>
        public virtual void OnInvoke(MethodInterceptionArgs args)
        {
            args.Proceed();
        }
    }
}

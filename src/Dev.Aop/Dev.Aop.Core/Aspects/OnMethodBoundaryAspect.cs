// 2015 Loredp Dev

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev.Aop.Core.IAspects;

namespace Dev.Aop.Core.Aspects
{
    /// <summary>
    /// Represents a class that can wrap itself around any given method call.
    /// </summary>
    public abstract class OnMethodBoundaryAspect : Aspect, IMethodAspect
    {
        /// <summary>
        /// Method executed before the body of method to which this aspect is applied.
        /// OnEntry method is a perfect place where to implement the logic such as input parameters logging, caching, authentication/authorization.
        /// </summary>
        /// <param name="args">Method arguments including return value and all necessary info.</param>
        public virtual void OnEntry(MethodExecutionArgs args)
        { }

        /// <summary>
        /// Method executed after the body of method to which this aspect is applied
        /// (this method is invoked from the finally block, it's mean that this method will be invoked in any way).
        /// This is a good place where to log the return value, inform other applications that the method has finished the execution.
        /// </summary>
        /// <param name="args">Method arguments including return value and all necessary info.</param>
        public virtual void OnExit(MethodExecutionArgs args)
        { }

        /// <summary>
        /// Method executed after the body of method to which this aspect is applied, 
        /// but only when the method successfully returns.
        /// </summary>
        /// <param name="args">Method arguments including return value and all necessary info.</param>
        public virtual void OnSuccess(MethodExecutionArgs args)
        { }

        /// <summary>
        /// When an exception is happened then this method will be called.
        /// This is a perfect place to log the error messages in an generic way and do something useful with that information.
        /// </summary>
        /// <param name="args">Method arguments including return value and all necessary info.</param>
        public virtual void OnException(MethodExecutionArgs args)
        { }
    }
}

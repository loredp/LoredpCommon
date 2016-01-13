﻿// 2015 Loredp Dev

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Dev.Aop.Core.Core
{
    internal delegate object LateBoundFunc(object[] arguments);
    internal delegate void LateBoundAction(object[] arguments);
    internal delegate void LateBoundSetter(object value);
    internal delegate object LateBoundGetter();

    internal class DelegateFactory
    {
        /// <summary>
        /// Creates a delegate to wrap a "function" (method which has return value).
        /// </summary>
        public static LateBoundFunc CreateFunction(object instance, MethodInfo method)
        {
            ParameterExpression args = Expression.Parameter(typeof(object[]), "arguments");
            MethodCallExpression call = Expression.Call(
                Expression.Constant(instance),
                method,
                CreateParameterExpressions(method, args));
            return Expression.Lambda<LateBoundFunc>(Expression.Convert(call, typeof(object)), args).Compile();
        }

        /// <summary>
        /// Creates a delegate to wrap a "siple method call" (method which has not return value, just returns void).
        /// </summary>
        public static LateBoundAction CreateMethodCall(object instance, MethodInfo method)
        {
            ParameterExpression args = Expression.Parameter(typeof(object[]), "arguments");
            MethodCallExpression call = Expression.Call(
                Expression.Constant(instance),
                method,
                CreateParameterExpressions(method, args));
            return Expression.Lambda<LateBoundAction>(call, args).Compile();
        }

        public static LateBoundSetter CreateSetter(object instance, MethodInfo method)
        {
            ParameterExpression value = Expression.Parameter(typeof(object), "value");
            MethodCallExpression call = Expression.Call(
                Expression.Constant(instance),
                method,
                Expression.Convert(value, method.GetParameters()[0].ParameterType));
            return Expression.Lambda<LateBoundSetter>(call, value).Compile();
        }

        public static LateBoundGetter CreateGetter(object instance, MethodInfo method)
        {
            MethodCallExpression call = Expression.Call(Expression.Constant(instance), method);
            return Expression.Lambda<LateBoundGetter>(Expression.Convert(call, typeof(object))).Compile();
        }

        public static Delegate CreateDelegate(object instance, MethodInfo method)
        {
            ParameterExpression[] argsExp = method.GetParameters().Select(
                arg => Expression.Parameter(arg.ParameterType, arg.Name)).ToArray();
            MethodCallExpression call = Expression.Call(Expression.Constant(instance), method, argsExp);
            return Expression.Lambda(call, argsExp).Compile();
        }

        private static Expression[] CreateParameterExpressions(MethodInfo method, Expression argumentsParameter)
        {
            return method.GetParameters().Select((parameter, index) =>
              Expression.Convert(
                Expression.ArrayIndex(argumentsParameter, Expression.Constant(index)), parameter.ParameterType)).ToArray();
        }
    }
}

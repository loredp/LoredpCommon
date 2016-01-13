using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Dev.Aop.Core;

namespace Dev.Aop.UnitTest.MethodInterceptionTest.OnInvoke
{
    class MyTestClass : IDynamicMetaObjectProvider
    {
        public bool OriginalMethodCalled { get; private set; }

        [ChangeArgumentsWithInvokationAspect]
        public void MethodWithRefArgs(ref int value)
        {
            OriginalMethodCalled = true;
            value = 90;
        }

        [ChangeArgumentsWithInvokationAspect]
        public void SimpleMethod(int value)
        {
            OriginalMethodCalled = true;
            value = 90;
        }

        [NotInvokeOriginalMethodAspect]
        public void SimpleMethod()
        {
            OriginalMethodCalled = true;
        }

        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new AspectWeaver(parameter, this);
        }
    }
}

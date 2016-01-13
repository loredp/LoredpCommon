using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Dev.Aop.Core;

namespace Dev.Aop.UnitTest.MethodBoundaryTest.OnEntry
{
    internal class OnEntryTest : IDynamicMetaObjectProvider
    {
        public bool OriginalMethodCalled { get; private set; }

        [ChangeArgumentAspect]
        public string ResturnStringArgument(string argument)
        {
            return argument;
        }

        [ChangeArgumentAspect]
        public string ResturnStringArgumentPassedAsRef(ref string argument)
        {
            return argument;
        }

        [ChangeObjectArgumentAspect]
        public object ResturnObjectArgument(object argument)
        {
            return argument;
        }

        [ChangeArgumentAspect]
        public void MethodWithRefArgs(ref int value)
        {
            OriginalMethodCalled = true;
        }

        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new AspectWeaver(parameter, this);
        }
    }
}

// 2015 Loredp Dev

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev.Aop.Core.Aspects
{
    /// <summary>
    /// Enumerate the possible behaviors of the calling method after the calling method has return.
    /// </summary>
    public enum FlowBehavior
    {
        Default,
        Continue,
        RethrowException,
        Return,
        ThrowException,
    }
}

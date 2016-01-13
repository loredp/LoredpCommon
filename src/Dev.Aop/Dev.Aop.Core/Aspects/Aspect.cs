// 2015 Loredp Dev

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev.Aop.Core.IAspects;

namespace Dev.Aop.Core.Aspects
{
    /// <summary>
    /// Base class for all aspects
    /// </summary>
    public abstract class Aspect : Attribute, IAspect
    {
        /// <summary>
        /// Gets or sets the weaving priority of the aspect.
        /// </summary>
        public int AspectPriority { get; set; }
    }
}

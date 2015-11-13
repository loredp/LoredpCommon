using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Components
{
    /// <summary>
    /// An attribute to indicate a class is a component.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentAttribute : Attribute
    {
        /// <summary>
        /// The lifetime of component.
        /// </summary>
        public LifeStyle LifeStyle { get; private set; }

        /// <summary>
        /// Default ctor.
        /// </summary>
        public ComponentAttribute() : this(LifeStyle.Singleton) { }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="lifeStyle"></param>
        public ComponentAttribute(LifeStyle lifeStyle)
        {
            this.LifeStyle = lifeStyle;
        }
    }

    public enum LifeStyle
    {
        /// <summary>
        /// Represents a component is a transient component.
        /// </summary>
        Transient,

        /// <summary>
        /// Represents a component is a singleton component.
        /// </summary>
        Singleton,
    }
}

// 2015 Loredp Dev

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dev.Aop.Core.Aspects
{
    /// <summary>
    /// Arguments of aspect which in executing for a property.
    /// </summary>
    public abstract class LocationInterceptionArgs : AdviceArgs
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        internal LocationInterceptionArgs(object instance, PropertyInfo property, object value)
            : base(instance)
        {
            Location = property;

            if (value != null) Value = value;
            else Value = property.PropertyType.IsValueType ? Activator.CreateInstance(property.PropertyType) : null;//init
        }

        /// <summary>
        /// Gets or sets the location value.
        /// </summary>
        public object Value { get; set; }

        // <summary>
        /// Gets the property location related to the aspect being executed.
        /// </summary>
        public PropertyInfo Location { get; private set; }

        /// <summary>
        /// Retrieves the current value of the location without overwriting the property.
        /// </summary>
        /// <returns>
        /// The current value of the location, as returned by the next node in the chain of invocation.
        /// </returns>
        public abstract object GetCurrentValue();

        /// <summary>
        /// Invokes the <b>Get Location Value</b> semantic on the next node in the chain of invocation and stores the location value in the property.
        /// </summary>
        public abstract void ProceedGetValue();

        /// <summary>
        /// Invokes the <b>Set Location Value</b> semantic on the next node in the chain of invocation and stores the value of the property into the location.
        /// </summary>
        public abstract void ProceedSetValue();

        /// <summary>
        /// Sets the value of the location without overwriting the property.
        /// </summary>
        /// <param name="value">The value to be passed to the next node in the chain of invocation.</param>
        public abstract void SetNewValue(object value);
    }
}

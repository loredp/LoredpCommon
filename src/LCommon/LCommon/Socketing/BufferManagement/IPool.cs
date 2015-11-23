using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Socketing.BufferManagement
{
    public interface IPool
    {
        /// <summary>
        /// Gets the total count.
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Gets the available count,the items count which are available to be used.
        /// </summary>
        int AvailableCount { get; }

        /// <summary>
        /// Shrinks this pool.
        /// </summary>
        bool Shrink { get; }
    }

    /// <summary>
    /// The basic pool interface for the object in type of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPool<T> : IPool
    {
        /// <summary>
        /// Gets one item from the pool.
        /// </summary>
        /// <returns></returns>
        T Get();

        /// <summary>
        /// Returns the specified item to the pool.
        /// </summary>
        /// <param name="item">The item.</param>
        void Return(T item);
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Socketing.BufferManagement
{
    public class IntelliPool<T> : IntelliPoolBase<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntelliPool{T}"/> class.
        /// </summary>
        /// <param name="initialCount">The initial count.</param>
        /// <param name="itemCreator">The item creator.</param>
        /// <param name="itemCleaner">The item cleaner.</param>
        /// <param name="itemPreGet">The item pre get.</param>
        public IntelliPool(int initialCount, IPoolItemCreator<T> itemCreator, Action<T> itemCleaner = null, Action<T> itemPreGet = null)
            : base(initialCount, itemCreator, itemCleaner, itemPreGet)
        {

        }
    }

    public abstract class IntelliPoolBase<T> : IPool<T>
    {
        private ConcurrentStack<T> _store;
        private IPoolItemCreator<T> _itemCreator;
        private byte _currentGeneration = 0;
        private int _nextExpandThreshold;
        private int _totalCount;
        private int _availableCount;
        private int _inExpanding = 0;
        private Action<T> _itemCleaner;
        private Action<T> _itemPreGet;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntelliPoolBase{T}"/> class.
        /// </summary>
        /// <param name="initialCount">The initial count.</param>
        /// <param name="itemCreator">The item creator.</param>
        /// <param name="itemCleaner">The item cleaner.</param>
        /// <param name="itemPreGet">The item pre get.</param>
        public IntelliPoolBase(int initialCount, IPoolItemCreator<T> itemCreator, Action<T> itemCleaner = null, Action<T> itemPreGet = null)
        {

        }

        #region IPool<T> 成员

        public T Get()
        {
            throw new NotImplementedException();
        }

        public void Return(T item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IPool 成员

        public int TotalCount
        {
            get { throw new NotImplementedException(); }
        }

        public int AvailableCount
        {
            get { throw new NotImplementedException(); }
        }

        public bool Shrink
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IPool<T> 成员

        T IPool<T>.Get()
        {
            throw new NotImplementedException();
        }

        void IPool<T>.Return(T item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IPool 成员

        int IPool.TotalCount
        {
            get { throw new NotImplementedException(); }
        }

        int IPool.AvailableCount
        {
            get { throw new NotImplementedException(); }
        }

        bool IPool.Shrink
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}

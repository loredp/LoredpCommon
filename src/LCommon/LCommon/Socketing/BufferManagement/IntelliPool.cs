using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Socketing.BufferManagement
{
    struct PoolItemState
    {
        public byte Generation { get; set; }
    }

    public class IntelliPool<T> : IntelliPoolBase<T>
    {
        private ConcurrentDictionary<T,PoolItemState> _bufferDict = new ConcurrentDictionary<T, PoolItemState>();
        private ConcurrentDictionary<T, T> _removedItemDict; 

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

        protected override void 
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
        /// Gets the current generation.
        /// </summary>
        /// <value>
        /// The current generation.
        /// </value>
        protected byte CurrentGeneration
        {
            get { return _currentGeneration; }
        }

        /// <summary>
        /// Gets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public int TotalCount
        {
            get { return _totalCount; }
        }

        /// <summary>
        /// Gets the available count, the items count which are available to be used.
        /// </summary>
        /// <value>
        /// The available count.
        /// </value>
        public int AvailableCount
        {
            get { return _availableCount; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntelliPoolBase{T}"/> class.
        /// </summary>
        /// <param name="initialCount">The initial count.</param>
        /// <param name="itemCreator">The item creator.</param>
        /// <param name="itemCleaner">The item cleaner.</param>
        /// <param name="itemPreGet">The item pre get.</param>
        public IntelliPoolBase(int initialCount, IPoolItemCreator<T> itemCreator, Action<T> itemCleaner = null,
            Action<T> itemPreGet = null)
        {
            _itemCreator = itemCreator;
            _itemCleaner = itemCleaner;
            _itemPreGet = itemPreGet;

            var list = new List<T>(initialCount);
            foreach (var item in itemCreator.Create(initialCount))
            {
                RegisterNewItem(item);
                list.Add(item);
            }
        }

        /// <summary>
        /// Registers the new item.
        /// </summary>
        /// <param name="item">The item.</param>
        protected abstract void RegisterNewItem(T item);

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

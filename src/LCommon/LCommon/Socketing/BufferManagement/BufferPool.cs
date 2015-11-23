using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Socketing.BufferManagement
{
    class BufferPool : IntelliPool<byte[]>, IBufferPool
    {
        public int BufferSize { get; private set; }

        public BufferPool(int bufferSize, int initialCount)
            : base(initialCount, new BufferItemCreator(bufferSize))
        {
            BufferSize = bufferSize;
        }

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

        #region IBufferPool 成员

        int IBufferPool.BufferSize
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IPool<byte[]> 成员

        byte[] IPool<byte[]>.Get()
        {
            throw new NotImplementedException();
        }

        void IPool<byte[]>.Return(byte[] item)
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

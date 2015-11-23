using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Socketing.BufferManagement
{
    public class BufferItemCreator : IPoolItemCreator<byte[]>
    {
        private int _bufferSize;

        #region Ctor
        
        public BufferItemCreator(int bufferSize)
        {
            _bufferSize = bufferSize;
        }

        #endregion

        #region IPoolItemCreator<byte[]> 成员

        public IEnumerable<byte[]> Create(int count)
        {
            return new BufferItemEnumerable(_bufferSize, count);
        }

        #endregion
    }

    class BufferItemEnumerable : IEnumerable<byte[]>
    {
        private int _bufferSize;
        private int _count;

        public BufferItemEnumerable(int bufferSize, int count)
        {
            _bufferSize = bufferSize;
            _count = count;
        }

        public IEnumerator<byte[]> GetEnumerator()
        {
            int count = _count;

            for (int i = 0; i < count; i++)
            {
                yield return new byte[_bufferSize];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

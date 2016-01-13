// 2015 Loredp Dev

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev.Aop.Core.Aspects
{
    public class Arguments : IEnumerable<object>
    {
        readonly object[] _objects;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="objects"></param>
        public Arguments(object[] objects)
        {
            _objects = objects;
        }

        public object this[int index]
        {
            get { return _objects[index]; }
            set { _objects[index] = value; }
        }

        public int Count
        {
            get { return _objects.Length; }
        }

        public object[] ToArray()
        {
            var array = new object[Count];
            _objects.CopyTo(array, 0);
            return array;
        }

        public IEnumerator<object> GetEnumerator()
        {
            for (uint i = 0; i < _objects.Length; i++)
            {
                yield return GetArgument(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        object GetArgument(uint index)
        {
            return _objects[index];
        }
    }
}

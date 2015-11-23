using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Extensions
{
    public static class ConcurrentDictionaryExtensions
    {
        public static void Remove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dict, TKey key)
        {
            TValue value;
            dict.TryRemove(key, out value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Serializing
{
    public interface IBinarySerializer
    {
        byte[] Serialize(object obj);

        object DeSerialize(byte[] data, Type type);

        T DeSerizlize<T>(byte[] data) where T : class;
    }
}

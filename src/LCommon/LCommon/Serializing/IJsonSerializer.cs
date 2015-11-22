using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Serializing
{
    public interface IJsonSerializer
    {
        string Serialize(object obj);

        object DeSerialize(string value, Type type);

        T Deserizlize<T>(string value) where T : class;
    }
}

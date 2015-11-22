using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCommon.Serializing
{
    public class DefaultJsonSerializer : IJsonSerializer
    {
        #region interface methods
        
        public string Serialize(object obj)
        {
            throw new NotImplementedException();
        }

        public object DeSerialize(string value, Type type)
        {
            throw new NotImplementedException();
        }

        public T Deserizlize<T>(string value) where T : class
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

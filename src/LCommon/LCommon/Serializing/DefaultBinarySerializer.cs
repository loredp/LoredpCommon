using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LCommon.Serializing
{
    public class DefaultBinarySerializer : IBinarySerializer
    {
        #region implement interface

        /// <summary>
        /// Serialized to byte[].
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                _binaryFormatter.Serialize(stream, obj);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Deaerialized from byte[] to object.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object DeSerialize(byte[] data, Type type)
        {
            using(MemoryStream stream = new MemoryStream(data))
            {
               return  _binaryFormatter.Deserialize(stream);   
            }
        }

        /// <summary>
        /// Deserialized to generic t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T DeSerizlize<T>(byte[] data) where T : class
        {
            using(MemoryStream stream = new MemoryStream(data))
            {
                return _binaryFormatter.Deserialize(stream) as T;
            }
        }

        #endregion

        #region property

        private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();

        #endregion
    }
}

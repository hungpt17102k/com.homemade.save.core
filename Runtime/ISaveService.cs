using com.homemade.core;
using System;
using com.homemade.encode.core;
using com.homemade.serialize.core;

namespace com.homemade.save.core
{
    public interface ISaveService : IService
    {
        ISave Saver { get; set; }
        IEncoder Encoder { get; set; }
        ISerializer Serializer { get; set; }

        void Save<T>(string key, T obj);
        T Load<T>(string key);
        void Delete(string key);
        void DeleteAll();
        bool Exists(string key);
    }
}

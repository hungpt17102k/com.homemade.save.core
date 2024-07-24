using com.homemade.core;

namespace com.homemade.save.core
{
    public interface ISaveService : IService
    {
        ISave Saver { get; set; }

        void Save<T>(string key, T obj);
        
        T Load<T>(string key);

        void Delete(string key);

        void DeleteAll();

        bool Exists(string key);
    }
}

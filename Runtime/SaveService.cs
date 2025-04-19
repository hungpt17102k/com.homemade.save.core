using com.homemade.encode.core;
using com.homemade.serialize.core;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace com.homemade.save.core
{
    public class SaveService : ISaveService
    {
        private ISave saver = new NullSave();
        private IEncoder encoder = new NullEncoder();
        private ISerializer serializer = new NullSerializer();

        public ISave Saver { get => saver; set => saver = value; }
        public IEncoder Encoder { get => encoder; set => encoder = value; }
        public ISerializer Serializer { get => serializer; set => serializer = value; }

        public int Priority => 0;

        public SaveService() { }

        public SaveService(ISave saver)
        {
            this.saver = saver;
        }

        public void Save<T>(string key, T obj)
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.Log("<color=red>Error:</color> The key can't be empty or null");
                return;
            }

            string serialized = serializer.Serialize(obj);
            string encoded = encoder.Encode(serialized);
            saver.Save(key, encoded);
        }

        public T Load<T>(string key)
        {
            

            if (string.IsNullOrEmpty(key))
            {
                Debug.Log("<color=red>Error:</color> The key can't be empty or null");
                return default;
            }

            T result = default;
            string data = saver.Load(key);
            string decoded = encoder.Decode(data);
            result = serializer.Deserialize<T>(decoded);

            return result;
        }

        public void Delete(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.Log("<color=red>Error:</color> The key can't be empty or null");
                return;
            }

            saver.Delete(key);
        }

        public void DeleteAll()
        {
            saver.DeleteAll();
        }

        public bool Exists(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.Log("<color=red>Error:</color> The key can't be empty or null");
                return false;
            }

            return saver.Exists(key);
        }

        public async UniTask OnInitialize()
        {
            await UniTask.CompletedTask;
        }
    }
}

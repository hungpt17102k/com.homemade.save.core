using Cysharp.Threading.Tasks;
using UnityEngine;

namespace com.homemade.save.core
{
    public class SaveService : ISaveService
    {
        public ISave Saver { get => saver; set => saver = value; }

        public int Priority => 0;

        private ISave saver;

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

            saver.Save(key, JsonUtility.ToJson(obj));
        }

        public T Load<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.Log("<color=red>Error:</color> The key can't be empty or null");
                return default;
            }

            string data = saver.Load(key);
            return JsonUtility.FromJson<T>(data);
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

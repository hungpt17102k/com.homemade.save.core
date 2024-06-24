using UnityEngine;

namespace com.homemade.save.core
{
    public class PlayerPrefsSave : ISave
    {
        public string Path { get => path; set => path = value; }
        private string path;

        public PlayerPrefsSave() { }

        public PlayerPrefsSave(string path)
        {
            this.path = path;
        }

        public void Save(string key, string data)
        {
            PlayerPrefs.SetString(key, data);
            PlayerPrefs.Save();
        }

        public string Load(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public void Delete(string key)
        {
            if (!Exists(key))
                return;

            PlayerPrefs.DeleteKey(key);
        }

        public void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public bool Exists(string key)
        {
            return PlayerPrefs.HasKey(key);
        }
    }
}

using System.Text;
using System.IO;
using System;
using UnityEngine;

namespace com.homemade.save.core
{
    public class IOSave : ISave
    {
        public string Path { get => path; set => path = value; }

        private string path;
        private Encoding encoding = Encoding.UTF8;

        public IOSave() { }

        public IOSave(string path)
        {
            this.path = path;
        }

        public IOSave(Encoding encoding, string path)
        {
            this.encoding = encoding;
            this.path = path;
        }

        public void Save(string key, string data)
        {
            string filePath = System.IO.Path.Combine(path, key);
            File.WriteAllText(filePath, data, encoding);
        }

        public string Load(string key)
        {
            try
            {
                string data = "";
                string filePath = System.IO.Path.Combine(path, key);
                data = File.ReadAllText(filePath, encoding);
                return data;
            }
            catch (Exception e)
            {
                Debug.Log($"<color=red>Error:</color> No exists file name: {key}.\nMessage: {e.Message}");
                return string.Empty;
            }
        }

        public void Delete(string key)
        {
            string filePath = System.IO.Path.Combine(path, key);

            if (File.Exists(filePath))
                File.Delete(filePath);
            else if (Directory.Exists(filePath))
                Directory.Delete(filePath, true);
        }

        public void DeleteAll()
        {
            DeleteAll(path);
        }

        public static void DeleteAll(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] files = info.GetFiles();

            for (int i = 0; i < files.Length; i++)
            { 
                try
                {
                    files[i].Delete();
                }
                catch (IOException e)
                {
                    Debug.Log(e.Message);
                }
            }

            DirectoryInfo[] dirs = info.GetDirectories();
            for (int i = 0; i < dirs.Length; i++)
            {
                try
                {
                    dirs[i].Delete(true);
                }
                catch (IOException e)
                {
                    Debug.Log(e.Message);
                }
            }
        }

        public bool Exists(string key)
        {
            string filePath = System.IO.Path.Combine(path, key);

            bool exists = Directory.Exists(filePath);
            if (!exists)
            {
                exists = File.Exists(filePath);
            }
            return exists;
        }
    }
}

namespace com.homemade.save.core
{
    public interface ISave
    {
        public string Path { get; set; }

        void Save(string key, string data);

        string Load(string key);

        void Delete(string key);

        void DeleteAll();

        bool Exists(string key);
    }
}

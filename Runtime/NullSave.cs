namespace com.homemade.save.core
{
    public class NullSave : ISave
    {
        public string Path { get => path; set => path = value; }
        private string path;

        public void Delete(string identifier)
        {
        }

        public void DeleteAll()
        {
        }

        public bool Exists(string identifier)
        {
            return false;
        }

        public bool IsSupport()
        {
            return true;
        }

        public string Load(string identifier)
        {
            return "";
        }

        public void Save(string identifier, string data)
        {
        }
    }
}
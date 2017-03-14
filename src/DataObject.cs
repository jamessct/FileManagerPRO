using ExtensionMethods;

namespace ConsoleApplication
{
    public class DataObject : IStorageItem
    {
        public string path;
        public string name;
        public string size;
        public string lastAccess;
        
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = Path.Name();
            }
        }
        public string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = Path.Size();
            }
        }
        public string LastAccess
        {
            get
            {
                return lastAccess;
            }
            set
            {
                lastAccess = Path.LastAccess();
            }
        }
    }
}
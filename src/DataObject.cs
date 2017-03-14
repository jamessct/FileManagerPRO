using ExtensionMethods;

namespace ConsoleApplication
{
    public abstract class DataObject : IStorageItem
    {
        public string path;
        public string name;
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

        public abstract string Size { get;set; }
    }
}
using System;
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
                //name = value;
                name = Path.Name();
                //Console.WriteLine(Path.Size());
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
                //size = value;
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
                //lastAccess = value;
                lastAccess = Path.LastAccess();
            }
        }
    }
}
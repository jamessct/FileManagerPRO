using System;
using System.IO;

namespace ConsoleApplication
{
    public class FileObject
    {
        ObjectManager app = new ObjectManager();
        long fileSize;
        public long Size
        {
            get
            {
                return fileSize;
            }
            set
            {
                fileSize = value;
            }
        }
        public string LastAccess;

        public string lastAccess
        {
            get
            {
                return LastAccess;
            }
            set
            {
                LastAccess = value;
            }
        }
    }
}
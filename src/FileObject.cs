using System;
using System.IO;

namespace ConsoleApplication
{ 
    public class FileObject : DataObject
    {
        AppHelper app = new AppHelper();
        //To include in this file:

        private static long fileSize;

        public static long Size
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

        private static string lastAccess;

        public static string LastAccess
        {
            get
            {
                return lastAccess;
            }
            set
            {
                lastAccess = value;
            }
        }
        //Name of file
        public string RemovePathFromName(string path)
        {
            int pathLength = path.LastIndexOf(@"\") + 1;
            string answer = path.Remove(0, pathLength);
            return answer;
        }

        //Size of file
        public long GetSizeOfFile(string filePath)
        {
            app.ThrowExceptionIfFileDoesntExist(filePath);
            
            FileInfo file = new FileInfo(filePath);
            long fileSize = file.Length;

            return fileSize;
        }

        //GetTimeStampForLastAccess
        public string GetTimeStampForLastAccess(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            
            DateTime time = info.LastAccessTime;
            var answer = time.ToString("yyyy/MM/dd HH:mm:ss.ff");
            return answer;
        }
    }
}
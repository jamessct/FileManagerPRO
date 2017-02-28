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

        public static bool CheckFileExists(string filePath)
        {
            if(File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public static void ThrowExceptionIfFileDoesntExist(string filePath)
        {
            if(CheckFileExists(filePath) == false)
            {
                throw new ArgumentException("This file does not exist");
            }
        }

        public static long GetSizeOfFile(string filePath)
        {
            ThrowExceptionIfFileDoesntExist(filePath);
            
            FileInfo file = new FileInfo(filePath);
            long fileSize = file.Length;

            return fileSize;
        }
    }
}
using System;
using System.IO;

namespace ConsoleApplication
{ 
    public static class FileObject
    {
        static ObjectManager app = new ObjectManager();
        public static long Size;
        // public static long Size
        // {
        //     get
        //     {
        //         return fileSize;
        //     }
        //     set
        //     {
        //         fileSize = value;
        //     }
        // }

        public static string LastAccess;

        // public static string LastAccess
        // {
        //     get
        //     {
        //         return lastAccess;
        //     }
        //     set
        //     {
        //         lastAccess = value;
        //     }
        // }

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

        public static string ReadTextFromFile(string filePath)
        {
            ThrowExceptionIfFileDoesntExist(filePath);

            string text = File.ReadAllText(filePath);

            return text;
        }

        public static bool SearchForTextInFile(string filePath, string textQuery)
        {
            ThrowExceptionIfFileDoesntExist(filePath);
            string text = ReadTextFromFile(filePath);

            if(text.Contains(textQuery))
            {
                return true;
            }

            return false;
        }

        public static void WriteTextToFile(string filePath, string text)
        {
            ThrowExceptionIfFileDoesntExist(filePath);

            File.WriteAllText(filePath, text);
        }

        public static void RemoveTextFromFile(string filePath)
        {
            File.WriteAllText(filePath, "");
        }

        public static int CountLinesInFile(string filePath)
        {
            int lineCount = File.ReadAllLines(filePath).Length;

            return lineCount;
        }

    }
}
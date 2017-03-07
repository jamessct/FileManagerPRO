using System;
using System.IO;

namespace ConsoleApplication
{
    public class FileObject
    {
        ObjectManager app = new ObjectManager();
        long fileSize;
        public long Size;
        // public long Size
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

        public string LastAccess;

        // public string LastAccess
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

        // public bool CheckFileExists(string filePath)
        // {
        //     if(File.Exists(filePath))
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }

        // public void ThrowExceptionIfFileDoesntExist(string filePath)
        // {
        //     if(CheckFileExists(filePath) == false)
        //     {
        //         throw new ArgumentException("This file does not exist");
        //     }
        // }

        // public long GetSizeOfFile(string filePath)
        // {
        //     ThrowExceptionIfFileDoesntExist(filePath);

        //     FileInfo file = new FileInfo(filePath);
        //     fileSize = file.Length;

        //     return fileSize;
        // }

        // public string ReadTextFromFile(string filePath)
        // {
        //     ThrowExceptionIfFileDoesntExist(filePath);

        //     string text = File.ReadAllText(filePath);

        //     return text;
        // }

        // public bool SearchForTextInFile(string filePath, string textQuery)
        // {
        //     ThrowExceptionIfFileDoesntExist(filePath);
        //     string text = ReadTextFromFile(filePath);

        //     if(text.Contains(textQuery))
        //     {
        //         return true;
        //     }

        //     return false;
        // }

        // public void WriteTextToFile(string filePath, string text)
        // {
        //     ThrowExceptionIfFileDoesntExist(filePath);

        //     File.WriteAllText(filePath, text);
        // }

        // public void RemoveTextFromFile(string filePath)
        // {
        //     File.WriteAllText(filePath, "");
        // }

        // public int CountLinesInFile(string filePath)
        // {
        //     int lineCount = File.ReadAllLines(filePath).Length;

        //     return lineCount;
        // }

    }
}
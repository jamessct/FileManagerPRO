using System;
using System.IO;

namespace ConsoleApplication
{
    public static class FolderObject
    {
        // public static bool CheckFolderExists(string folderPath)
        // {
        //     if(Directory.Exists(folderPath))
        //     {
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }

        // public static void ThrowExceptionIfFolderDoesntExist(string folderPath)
        // {
        //     if(CheckFolderExists(folderPath) == false)
        //     {
        //         throw new ArgumentException("This folder does not exist");
        //     }
        // }

        // public static long GetSizeOfDirectory(string folderPath)
        // {
        //     ThrowExceptionIfFolderDoesntExist(folderPath);

        //     long totalSize = 0;
        //     string[] contents = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

        //     foreach (string name in contents)
        //     {
        //         FileInfo file = new FileInfo(name);
        //         totalSize = totalSize + file.Length;
        //     }

        //     return totalSize;
        // }
        // public static string[] ListFilesInDirectory(string folderPath)
        // {
        //     ThrowExceptionIfFolderDoesntExist(folderPath);

        //     string[] list = Directory.GetFiles(folderPath);

        //     if(list.Length == 0)
        //     {
        //         throw new ArgumentException("There are no files in this directory");
        //     }
        //     else
        //     {
        //         return list;
        //     }
        // }

        // public static string[] ListSubfoldersInDirectory(string folderPath)
        // {
        //     ThrowExceptionIfFolderDoesntExist(folderPath);

        //     string[] list = Directory.GetDirectories(folderPath);

        //     if(list.Length == 0)
        //     {
        //         throw new ArgumentException("There are no subfolders in this directory");
        //     }
        //     else return list;
        // }

        // public static long GetSizeOfFileList(string folderPath)
        // {
        //     ThrowExceptionIfFolderDoesntExist(folderPath);

        //     long totalSize = 0;
        //     string[] fileList = Directory.GetFiles(folderPath);

        //     foreach (string name in fileList)
        //     {
        //         FileInfo file = new FileInfo(name);
        //         totalSize = totalSize + file.Length;
        //     }
        //     return totalSize;
        // }
    }
}
using System;
using System.IO;
using System.Collections.Generic;
using ExtensionMethods;

namespace ConsoleApplication
{
    public static class ObjectManager
    {
        public static string GetTimeStampForLastAccess(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            DateTime time = info.LastAccessTime;
            return time.ToString("yyyy/MM/dd HH:mm:ss.ff");
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
            return file.Length;;
        }

        public static string ReadTextFromFile(string filePath)
        {
            ThrowExceptionIfFileDoesntExist(filePath);
            return File.ReadAllText(filePath);
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
            ThrowExceptionIfFileDoesntExist(filePath);
            File.WriteAllText(filePath, "");
        }

        public static int CountLinesInFile(string filePath)
        {
            ThrowExceptionIfFileDoesntExist(filePath);
            return File.ReadAllLines(filePath).Length;
        }

        //Not totally sure what the following 2 methods could be used for practically, but here they are anyway.
        public static byte[] ReadBytesFromFile(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        public static void TruncateFile(string filePath)
        {
            ThrowExceptionIfFileDoesntExist(filePath);
            FileStream stream = File.Open(filePath, FileMode.Truncate);
        }

        public static bool CheckFolderExists(string folderPath)
        {
            if(Directory.Exists(folderPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ThrowExceptionIfFolderDoesntExist(string folderPath)
        {
            if(CheckFolderExists(folderPath) == false)
            {
                throw new ArgumentException("This folder does not exist");
            }
        }

        public static long GetSizeOfDirectory(string folderPath)
        {
            ThrowExceptionIfFolderDoesntExist(folderPath);
            long totalSize = 0;
            string[] contents = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            foreach (string name in contents)
            {
                FileInfo file = new FileInfo(name);
                totalSize = totalSize + file.Length;
            }
            return totalSize;
        }
        public static string[] ListFilesInDirectory(string folderPath)
        {
            ThrowExceptionIfFolderDoesntExist(folderPath);
            string[] list = Directory.GetFiles(folderPath);

            if(list.Length == 0)
            {
                throw new ArgumentException("There are no files in this directory");
            }
            else
            {
                return list;
            }
        }

        public static string[] ListSubfoldersInDirectory(string folderPath)
        {
            ThrowExceptionIfFolderDoesntExist(folderPath);
            string[] list = Directory.GetDirectories(folderPath);

            if(list.Length == 0)
            {
                throw new ArgumentException("There are no subfolders in this directory");
            }
            else
            {
                return list;
            } 
        }

        public static long GetSizeOfFileList(string folderPath)
        {
            ThrowExceptionIfFolderDoesntExist(folderPath);
            long totalSize = 0;
            string[] fileList = Directory.GetFiles(folderPath);

            foreach (string name in fileList)
            {
                FileInfo file = new FileInfo(name);
                totalSize = totalSize + file.Length;
            }
            return totalSize;
        }

        public static void CreateNewFile(string filePath)
        {
            if(CheckFileExists(filePath) == true || !filePath.Contains(@":\"))
            {
                throw new ArgumentException("A file already exists at this location, or this is not a valid file path");
            }
            File.Create(filePath);
        }

        public static void RemoveFile(string filePath)
        {
            ThrowExceptionIfFileDoesntExist(filePath);
            File.Delete(filePath);
        }

        public static void MoveFile(string filePath, string destinationPath)
        {
            ThrowExceptionIfFileDoesntExist(filePath);

            if(CheckFileExists(destinationPath) == true || !destinationPath.Contains(@":\") || !filePath.Contains(@":\"))
            {
                throw new ArgumentException("A file already exists at the destination path!");
            }
            File.Move(filePath, destinationPath);
        }

        public static void RenameFile(string oldPath, string newName)
        {
            ThrowExceptionIfFileDoesntExist(oldPath);
            int newPathLength = oldPath.LastIndexOf("\\") + 1;
            int folderCount = oldPath.Length - newPathLength;
            string newPath = (oldPath.Remove(newPathLength, folderCount)) + newName;

            if (File.Exists(newPath) == true || !newPath.Contains(@":\"))
            {
                throw new ArgumentException("A file already exists at the destination path");
            }
            File.Move(oldPath, newPath);
        }

        public static void CreateNewFolder(string newFolderPath)
        {
            if (CheckFolderExists(newFolderPath) == true || !newFolderPath.Contains(@":\"))
            {
                throw new ArgumentException("Invalid input");
            }
            Directory.CreateDirectory(newFolderPath);
        }

        private static void ClearFilesFromFolder(DirectoryInfo directory)
        {
            foreach(FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            foreach(DirectoryInfo subdirectory in directory.GetDirectories())
            {
                subdirectory.Delete();
            }
        }

        public static void RemoveFolder(string folderPath, bool recursive)
        {
            ThrowExceptionIfFolderDoesntExist(folderPath);
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            string[] list = Directory.GetFiles(folderPath);

            if (list.Length > 0)
            {
                ClearFilesFromFolder(directory);
            }

            if (!folderPath.Contains(@":\"))
            {
                throw new ArgumentException("This is not a valid file path!");
            }

            Directory.Delete(folderPath, recursive);
        }

        public static void MoveFolder(string folderPath, string newLocation)
        {
            ThrowExceptionIfFolderDoesntExist(folderPath);

            if (Directory.Exists(newLocation) == true)
            {
                throw new ArgumentException("pls wrk");
            }
            Directory.Move(folderPath, newLocation);
        }

        public static void RenameFolder(string oldPath, string newName)
        {
            ThrowExceptionIfFolderDoesntExist(oldPath);
            int newPathLength = oldPath.LastIndexOf(@"\") + 1;
            int folderCount = (oldPath.Length - newPathLength);
            string newPath = (oldPath.Remove(newPathLength, folderCount)) + newName;

            if (Directory.Exists(newPath) == true)
            {
                throw new ArgumentException("This should be getting caught");
            }
            else
            {
                Directory.Move(oldPath, newPath);
            }
        }

        public static string RemovePathFromName(string path)
        {
            int pathLength = path.LastIndexOf(@"\") + 1;
            return path.Remove(0, pathLength);
        }

        public static void CreateIndexFile(string folderPath)
        {
            ThrowExceptionIfFolderDoesntExist(folderPath);
            TableMaker table = new TableMaker();
            ListMaker list = new ListMaker();
            string indexPath = folderPath + "\\index.txt";
            FileStream f = File.Create(indexPath);
            f.Dispose();
            string[] files = Directory.GetFiles(folderPath);
            List<DataObject> fileList = new List<DataObject>();

            foreach(string file in files)
            {
                DataObject obj = new FileObject();
                obj.Path = file;
                obj.Name = file.Name();
                obj.Size = file.FileSize();
                obj.LastAccess = file.LastAccess();
                fileList.Add(obj);
            }

            string[] folders = Directory.GetDirectories(folderPath);
            List<DataObject> folderList = new List<DataObject>();

            foreach(string folder in folders)
            {
                DataObject obj = new FolderObject();
                obj.Path = folder;
                obj.Name = folder.Name();
                obj.Size = folder.FolderSize();
                obj.LastAccess = folder.LastAccess();
                folderList.Add(obj);
            }
            
            string[] fileTable = list.CreateTable(fileList);
            string[] folderTable = list.CreateTable(folderList);
            string[] headings = {"Name", "Size", "Last Accessed"};

            using (StreamWriter sw = File.AppendText(indexPath))
            {
                sw.WriteLine("Files in " + indexPath);
                sw.WriteLine();

                sw.WriteLine(table.PrintLine());
                sw.WriteLine(table.PrintRow(headings));
                sw.WriteLine(table.PrintLine());

                foreach (string row in fileTable)
                {
                    sw.WriteLine(row);
                }

                sw.WriteLine();
                sw.WriteLine("Subfolders in " + indexPath);
                sw.WriteLine();

                sw.WriteLine(table.PrintLine());
                sw.WriteLine(table.PrintRow(headings));
                sw.WriteLine(table.PrintLine());

                foreach(string row in folderTable)
                {
                    sw.WriteLine(row);
                }
            }
        }
    }
}
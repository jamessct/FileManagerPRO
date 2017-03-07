using System;
using System.IO;

namespace ConsoleApplication
{
    public class ObjectManager
    {
        FileObject file = new FileObject();
        //FolderObject folder = new FolderObject();

        public bool CheckFileExists(string filePath)
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
       
        public void ThrowExceptionIfFileDoesntExist(string filePath)
        {
            if(CheckFileExists(filePath) == false)
            {
                throw new ArgumentException("This file does not exist");
            }
        }

        public long GetSizeOfFile(string filePath)
        {
            ThrowExceptionIfFileDoesntExist(filePath);
            
            FileInfo file = new FileInfo(filePath);
            long fileSize = file.Length;

            return fileSize;
        }

        public string ReadTextFromFile(string filePath)
        {
            ThrowExceptionIfFileDoesntExist(filePath);

            string text = File.ReadAllText(filePath);

            return text;
        }

        public bool SearchForTextInFile(string filePath, string textQuery)
        {
            ThrowExceptionIfFileDoesntExist(filePath);
            string text = ReadTextFromFile(filePath);

            if(text.Contains(textQuery))
            {
                return true;
            }

            return false;
        }

        public void WriteTextToFile(string filePath, string text)
        {
            ThrowExceptionIfFileDoesntExist(filePath);

            File.WriteAllText(filePath, text);
        }

        public void RemoveTextFromFile(string filePath)
        {
            File.WriteAllText(filePath, "");
        }

        public int CountLinesInFile(string filePath)
        {
            int lineCount = File.ReadAllLines(filePath).Length;

            return lineCount;
        }

        public void CreateNewFile(string filePath)
        {
            if(file.CheckFileExists(filePath) == true || !filePath.Contains(@":\"))
            {
                throw new ArgumentException("A file already exists at this location, or this is not a valid file path");
            }
            File.Create(filePath);
        }

        public void RemoveFile(string filePath)
        {
            file.ThrowExceptionIfFileDoesntExist(filePath);

            File.Delete(filePath);
        }

        public void MoveFile(string filePath, string destinationPath)
        {
            file.ThrowExceptionIfFileDoesntExist(filePath);

            if(file.CheckFileExists(destinationPath) == true || !destinationPath.Contains(@":\") || !filePath.Contains(@":\"))
            {
                throw new ArgumentException("A file already exists at the destination path!");
            }

            File.Move(filePath, destinationPath);
        }

        public void RenameFile(string oldPath, string newName)
        {
            file.ThrowExceptionIfFileDoesntExist(oldPath);

            int newPathLength = oldPath.LastIndexOf("\\") + 1;
            int folderCount = (oldPath.Length - newPathLength);
            string slicedString = oldPath.Remove(newPathLength, folderCount);
            string newPath = slicedString + newName;

            if (File.Exists(newPath) == true || !newPath.Contains(@":\"))
            {
                throw new ArgumentException("A file already exists at the destination path");
            }

            File.Move(oldPath, newPath);
        }

        public void CreateNewFolder(string newFolderPath)
        {
            if (FolderObject.CheckFolderExists(newFolderPath) == true || !newFolderPath.Contains(@":\"))
            {
                throw new ArgumentException("Invalid input");
            }

            Directory.CreateDirectory(newFolderPath);
        }

        private void ClearFilesFromFolder(DirectoryInfo directory)
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

        public void RemoveFolder(string folderPath, bool recursive)
        {
            FolderObject.ThrowExceptionIfFolderDoesntExist(folderPath);

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

        public void MoveFolder(string folderPath, string newLocation)
        {
            FolderObject.ThrowExceptionIfFolderDoesntExist(folderPath);

            if (Directory.Exists(newLocation) == true)
            {
                throw new ArgumentException("pls wrk");
            }
            Directory.Move(folderPath, newLocation);
        }

        public void RenameFolder(string oldPath, string newName)
        {
            FolderObject.ThrowExceptionIfFolderDoesntExist(oldPath);

            int newPathLength = oldPath.LastIndexOf(@"\") + 1;
            int folderCount = (oldPath.Length - newPathLength);
            string slicedString = oldPath.Remove(newPathLength, folderCount);
            string newPath = slicedString + newName;

            if (Directory.Exists(newPath) == true)
            {
                throw new ArgumentException("This should be getting caught");
            }
            else
            {
                Directory.Move(oldPath, newPath);
            }
        }

        public void CreateIndexFile(string folderPath)
        {
            //Console.WriteLine("TEST2");
            FolderObject.ThrowExceptionIfFolderDoesntExist(folderPath);

            string indexPath = folderPath + "\\Index.txt";
            FileStream f = File.Create(indexPath);
            f.Dispose();

            TableMaker table = new TableMaker();
            ListMaker list = new ListMaker();
            string[] files = Directory.GetFiles(folderPath);
            string[] folders = Directory.GetDirectories(folderPath);
            string[] fileTable = list.CreateTable(files, "file");
            string[] folderTable = list.CreateTable(folders, "folder");
            string[] headings = {"", "Name", "Size", "Last Accessed"};

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
using System;
using System.IO;
using System.Text;

namespace ConsoleApplication
{
    public class AppHelper
    {
        public bool CheckFolderExists(string folderPath)
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

        private void ThrowExceptionIfFolderDoesntExist(string folderPath)
        {
            if(this.CheckFolderExists(folderPath) == false)
            {
                throw new ArgumentException("This folder does not exist");
            }
        }

        private void ThrowExceptionIfFileDoesntExist(string filePath)
        {
            if(this.CheckFileExists(filePath) == false)
            {
                throw new ArgumentException("This file does not exist");
            }
        }

        public string[] ListFilesInDirectory(string folderPath)
        {
            this.ThrowExceptionIfFolderDoesntExist(folderPath);

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

        public string[] ListSubfoldersInDirectory(string folderPath)
        {
            this.ThrowExceptionIfFolderDoesntExist(folderPath);

            string[] list = Directory.GetDirectories(folderPath);

            if(list.Length == 0)
            {
                throw new ArgumentException("There are no subfolders in this directory");
            }
            else return list;
        }

        public long GetSizeOfFile(string filePath)
        {
            this.ThrowExceptionIfFileDoesntExist(filePath);
            
            FileInfo file = new FileInfo(filePath);
            long fileSize = file.Length;

            return fileSize;
        }

        public long GetSizeOfFileList(string folderPath)
        {
            this.ThrowExceptionIfFolderDoesntExist(folderPath);

            long totalSize = 0;
            string[] fileList = Directory.GetFiles(folderPath);

            foreach (string name in fileList)
            {
                FileInfo file = new FileInfo(name);
                totalSize = totalSize + file.Length;
            }
            
            return totalSize;
        }

        public long GetSizeOfDirectory(string folderPath)
        {
            this.ThrowExceptionIfFolderDoesntExist(folderPath);

            long totalSize = 0;
            string[] contents = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            foreach (string name in contents)
            {
                FileInfo file = new FileInfo(name);
                totalSize = totalSize + file.Length;
            }

            return totalSize;
        }

        public void CreateNewFile(string filePath)
        {
            if(this.CheckFileExists(filePath) == true || !filePath.Contains(":\\"))
            {
                throw new ArgumentException("A file already exists at this location, or this is not a valid file path");
            }

            File.Create(filePath);
        }

        public void RemoveFile(string filePath)
        {
            this.ThrowExceptionIfFileDoesntExist(filePath);

            File.Delete(filePath);
        }

        public void MoveFile(string filePath, string destinationPath)
        {
            this.ThrowExceptionIfFileDoesntExist(filePath);

            if(this.CheckFileExists(destinationPath) == true)
            {
                throw new ArgumentException("A file already exists at the destination path!");
            }

            File.Move(filePath, destinationPath);
        }

        public string ReadTextFromFile(string filePath)
        {
            this.ThrowExceptionIfFileDoesntExist(filePath);

            string text = File.ReadAllText(filePath);

            return text;
        }

        public bool SearchForTextInFile(string filePath, string textQuery)
        {
            this.ThrowExceptionIfFileDoesntExist(filePath);
            string text = this.ReadTextFromFile(filePath);

            if(text.Contains(textQuery))
            {
                return true;
            }

            return false;
        }

        public void WriteTextToFile(string filePath, string text)
        {
            this.ThrowExceptionIfFileDoesntExist(filePath);

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

        public string GetTimeStampForLastAccess(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            
            DateTime time = info.LastAccessTime;
            var answer = time.ToString("yyyy/MM/dd HH:mm:ss.ff");
            return answer;
        }

        public void CreateNewFolder(string newFolderPath)
        {
            if(this.CheckFolderExists(newFolderPath) == true || !newFolderPath.Contains(":\\"))
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
            this.ThrowExceptionIfFolderDoesntExist(folderPath);

            DirectoryInfo directory = new DirectoryInfo(folderPath);
            string[] list = Directory.GetFiles(folderPath);

            if (list.Length > 0)
            {
                this.ClearFilesFromFolder(directory);
            }
            
            Directory.Delete(folderPath, recursive);          
        }

        public void MoveFolder(string folderPath, string newLocation)
        {
            this.ThrowExceptionIfFolderDoesntExist(folderPath);
            Directory.Move(folderPath, newLocation);
        }

        public void RenameFolder(string oldPath, string newName)
        {
            this.ThrowExceptionIfFolderDoesntExist(oldPath);

            int newPathLength = oldPath.LastIndexOf("\\") + 1;
            int folderCount = (oldPath.Length - newPathLength);
            string slicedString = oldPath.Remove(newPathLength, folderCount);
            string newPath = slicedString + newName;
            Console.WriteLine(newPath);
            Directory.Move(oldPath, newPath);
        }

        public string RemovePathFromName(string path)
        {
            int pathLength = path.LastIndexOf("\\") + 1;
            string answer = path.Remove(0, pathLength);
            return answer;
        }

        public void CreateIndexFile(string folderPath)
        {
            this.ThrowExceptionIfFolderDoesntExist(folderPath);

            string indexPath = folderPath + "\\Index.txt";
            FileStream f = File.Create(indexPath);
            f.Dispose();
        
            ListMaker table = new ListMaker();
            string[] files = Directory.GetFiles(folderPath);
            string[] folders = Directory.GetDirectories(folderPath);
            string[] fileTable = table.CreateTable(files, "file", Options.input);
            string[] folderTable = table.CreateTable(folders, "folder", Options.input);

            using (StreamWriter sw = File.AppendText(indexPath))
            {
                sw.WriteLine("Files in " + indexPath);
                sw.WriteLine();

                foreach (string row in fileTable)
                {
                    sw.WriteLine(row);
                }

                sw.WriteLine();
                sw.WriteLine("Subfolders in " + indexPath);
                sw.WriteLine();

                foreach(string row in folderTable)
                {
                    sw.WriteLine(row);
                }
            }
        }
    }
}
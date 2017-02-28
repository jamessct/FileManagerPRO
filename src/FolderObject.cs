namespace ConsoleApplication
{
    public class FolderObject : DataObject
    {
        private static long GetSizeOfFileList(string folderPath)
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
    }
}
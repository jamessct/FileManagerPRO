using ConsoleApplication;

namespace ExtensionMethods
{
    public static class ObjectExtensionClass
    {
        public static string Name(this string filePath)
        {
            return ObjectManager.RemovePathFromName(filePath);
        }

        public static string FileSize(this string filePath)
        {
            long answer = ObjectManager.GetSizeOfFile(filePath);
            return Utilities.SelectAppropriateFileSizeFormat(answer);
        }

        public static string FolderSize(this string folderPath)
        {
            long answer = ObjectManager.GetSizeOfDirectory(folderPath);
            return Utilities.SelectAppropriateFileSizeFormat(answer);
        }

        public static string LastAccess(this string path)
        {
            return ObjectManager.GetTimeStampForLastAccess(path);
        }
    }
}
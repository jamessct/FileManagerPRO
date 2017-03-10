using ConsoleApplication;
namespace ExtensionMethods
{
    public static class FileSizeExtension
    {
        //static ObjectManager app = new ObjectManager();
        //static FolderObject folder = new FolderObject();
        //static FileObject file = new FileObject();

        public static string Name(this string filePath)
        {
            string answer = ObjectManager.RemovePathFromName(filePath);
            return answer;
        }
        public static string FileSize(this string filePath)
        {
            long answer = ObjectManager.GetSizeOfFile(filePath);
            string answerStringified = Utilities.SelectAppropriateFileSizeFormat(answer);
            return answerStringified;
        }

        public static string FolderSize(this string folderPath)
        {
            long answer = ObjectManager.GetSizeOfDirectory(folderPath);
            string answerStringified = Utilities.SelectAppropriateFileSizeFormat(answer);
            return answerStringified;
        }

        public static string LastAccess(this string path)
        {
            string answer = ObjectManager.GetTimeStampForLastAccess(path);
            return answer;
        }
    }
}
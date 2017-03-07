using ConsoleApplication;
namespace ExtensionMethods
{
    public static class FileSizeExtension
    {
        static ObjectManager app = new ObjectManager();
        //static FolderObject folder = new FolderObject();
        //static FileObject file = new FileObject();
        public static string FileSize(this string filePath)
        {
            long answer = app.GetSizeOfFile(filePath);
            string answerStringified = Utilities.SelectAppropriateFileSizeFormat(answer);
            return answerStringified;
        }

        public static string FolderSize(this string folderPath)
        {
            long answer = FolderObject.GetSizeOfDirectory(folderPath);
            string answerStringified = Utilities.SelectAppropriateFileSizeFormat(answer);
            return answerStringified;
        }
    }
}
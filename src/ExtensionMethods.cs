using ConsoleApplication;
namespace ExtensionMethods
{
    public static class FileSizeExtension
    {
        static AppHelper app = new AppHelper();
        public static string FileSize(this string filePath)
        {
            long answer = app.GetSizeOfFile(filePath);
            string answerStringified = Utilities.SelectAppropriateFileSizeFormat(answer);
            return answerStringified;
        }

        public static string FolderSize(this string folderPath)
        {
            long answer = app.GetSizeOfDirectory(folderPath);
            string answerStringified = Utilities.SelectAppropriateFileSizeFormat(answer);
            return answerStringified;
        }
    }
}
using ConsoleApplication;
namespace ExtensionMethods
{
    public static class FileExtensions
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
            long answer = app.GetSizeOfFileList(folderPath);
            string answerStringified = Utilities.SelectAppropriateFileSizeFormat(answer);
            return answerStringified;
        }

        public static string GetLastAccess(this string path)
        {
            string answer = app.GetTimeStampForLastAccess(path);
            return answer;
        }
    }


}

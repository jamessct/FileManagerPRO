using ConsoleApplication;
namespace ExtensionMethods
{
    public static class PathExtensions
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

        public static string LastAccess(this string path)
        {
            string answer = app.GetTimeStampForLastAccess(path);
            return answer;
        }

        public static string FileName(this string path)
        {
            string answer = app.RemovePathFromName(path);
            return answer;
        }
    }


}

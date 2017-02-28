using ConsoleApplication;
namespace ExtensionMethods
{
    public static class FileSizeExtension
    {
        public static string FileSize(this string filePath)
        {
            long answer = FileObject.GetSizeOfFile(filePath);
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
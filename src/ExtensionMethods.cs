using System;
using ConsoleApplication;

namespace ExtensionMethods
{
    public static class FileSizeExtension
    {
        public static string Name(this string filePath)
        {
            string answer = ObjectManager.RemovePathFromName(filePath);
            return answer;
        }

        public static string Size(this string path)
        {
            try
            {
                long answer = ObjectManager.GetSizeOfFile(path);
                string answerStringified = Utilities.SelectAppropriateFileSizeFormat(answer);
                return answerStringified;   
            }
            catch(ArgumentException)
            {
                long answer = ObjectManager.GetSizeOfDirectory(path);
                string answerStringified = Utilities.SelectAppropriateFileSizeFormat(answer);
                return answerStringified;
            }
        }
        // public static string FileSize(this string filePath)
        // {
        //     long answer = ObjectManager.GetSizeOfFile(filePath);
        //     string answerStringified = Utilities.SelectAppropriateFileSizeFormat(answer);
        //     return answerStringified;
        // }

        // public static string FolderSize(this string folderPath)
        // {
        //     long answer = ObjectManager.GetSizeOfDirectory(folderPath);
        //     string answerStringified = Utilities.SelectAppropriateFileSizeFormat(answer);
        //     return answerStringified;
        // }

        public static string LastAccess(this string path)
        {
            string answer = ObjectManager.GetTimeStampForLastAccess(path);
            return answer;
        }
    }
}
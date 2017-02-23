using System;
using System.IO;

namespace ConsoleApplication
{
    public class DataObject
    {
        public string RemovePathFromName(string path)
        {
            int pathLength = path.LastIndexOf(@"\") + 1;
            string answer = path.Remove(0, pathLength);
            return answer;
        }
        public string GetTimeStampForLastAccess(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            
            DateTime time = info.LastAccessTime;
            var answer = time.ToString("yyyy/MM/dd HH:mm:ss.ff");
            return answer;
        }
    }
}
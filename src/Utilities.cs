using System;

namespace ConsoleApplication
{
    public static class Utilities
    {
        public static string SelectAppropriateFileSizeFormat(long bytes)
        {
            if (bytes > 1048576)
            {
                double megabytes = (bytes / 1048576f);
                double rounded = Math.Round(megabytes, 2);
                string answer = (rounded + "MB");
                return answer;
            }
            if (bytes > 1073741824)
            {
                double gigabytes = (bytes / 1073741824f);
                double rounded = Math.Round(gigabytes, 2);
                string answer = (rounded + "GB");
                return answer;
            }
            else
            {
                double kilobytes = (bytes / 1024f);
                double rounded = Math.Round(kilobytes, 2);
                string answer = (rounded + "KB");
                return answer;
            }
        }
    }
}
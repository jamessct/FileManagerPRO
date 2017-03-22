using System;

namespace ConsoleApplication
{
    public static class Utilities
    {
        public static string SelectAppropriateFileSizeFormat(long bytes)
        {
            if (bytes > 1048576 && bytes < 1073741824)
            {
                double megabytes = (bytes / 1048576f);
                double rounded = Math.Round(megabytes, 2);
                return (rounded + "MB");
            }
            if (bytes > 1073741824)
            {
                double gigabytes = (bytes / 1073741824f);
                double rounded = Math.Round(gigabytes, 2);
                return (rounded + "GB");
            }
            else
            {
                double kilobytes = (bytes / 1024f);
                double rounded = Math.Round(kilobytes, 2);
                return (rounded + "KB");
            }
        }
    }
}
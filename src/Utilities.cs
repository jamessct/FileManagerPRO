namespace ConsoleApplication
{
    public static class Utilities
    {
        public static string SelectAppropriateFileSizeFormat(long bytes)
        {
            if (bytes > 1048576)
            {
                double megabytes = (bytes / 1048576f);
                string answer = (megabytes + "mb");
                return answer;
            }
            if (bytes > 1073741824)
            {
                double gigabytes = (bytes / 1073741824f);
                string answer = (gigabytes + "mb");
                return answer;
            }
            else
            {
                double kilobytes = (bytes / 1024f);
                string answer = (kilobytes + "kb");
                return answer;
            }
        }
    }
}
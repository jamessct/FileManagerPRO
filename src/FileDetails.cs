using System;
using ExtensionMethods;

namespace ConsoleApplication
{
    class File
    {
        public string GetName(string file)
        {
            string path = file.FileName();
            return path;
        }
    }
}
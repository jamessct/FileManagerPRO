// This will make a list out of the data object
using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class FileListMaker
    {
        public List<DataObject> FileList(DataObject file)
        {
            DataObject test1 = new DataObject();
            DataObject test2 = new DataObject();
            DataObject test3 = new DataObject();

            test1.Name = "file1.exe";
            test1.Size = "12MB";
            test1.LastAccess = "yesterday";

            test2.Name ="file2.txt";
            test2.Size = "12MB";
            test2.LastAccess = "today";

            test3.Name = "file3.jpg";
            test3.Size = "11MB";
            test3.LastAccess = "2morrow";

            Console.WriteLine("test1.Name = " + test1.Name);
            List<DataObject> FileList = new List<DataObject>();
            FileList.Add(test1);
            FileList.Add(test2);
            FileList.Add(test3);

            FileList.ForEach(Console.WriteLine);
            
            return FileList;
        }
    }
}
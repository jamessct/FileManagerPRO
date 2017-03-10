using System.Collections.Generic;

namespace ConsoleApplication
{
    public class FileList
    {
        public List<DataObject> Files(DataObject file)
        {
            List<DataObject> FileList = new List<DataObject>();
            FileList.Add(file);
            return FileList;
        }
    }
}
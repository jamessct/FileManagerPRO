using System.Collections.Generic;

namespace ConsoleApplication
{
    public class FolderList
    {
        public List<DataObject> Folders(DataObject folder)
        {
            List<DataObject> FolderList = new List<DataObject>();
            FolderList.Add(folder);
            return FolderList;
        }
    }  
}

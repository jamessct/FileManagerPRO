using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class FolderListMaker
    {
        public List<DataObject> FolderList(DataObject folder)
        {
            List<DataObject> FolderList = new List<DataObject>();
            FolderList.Add(folder);
            return FolderList;
        }
    }  
}

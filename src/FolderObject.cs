//Going forward, FileObject and FolderObject will perhaps be changed into object classes
//that inheret from DataObject...

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

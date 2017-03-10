//Going forward, FileObject and FolderObject will perhaps be changed into object classes
//that inheret from DataObject...

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
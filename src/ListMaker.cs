using System.Collections.Generic;

namespace ConsoleApplication
{
    public class ListMaker
    {
        public string[] CreateTable(List<DataObject> ObjectList)
        {
            TableMaker table = new TableMaker();
            List<string> ObjList = new List<string>();
            List<string> result = new List<string>();

            foreach(var obj in ObjectList)
            {
                ObjList.Add(obj.Name);
                ObjList.Add(obj.Size);
                ObjList.Add(obj.LastAccess);
                string[] row = ObjList.ToArray(); 
                result.Add(table.PrintRow(row));
                result.Add(table.PrintLine());
                ObjList.Clear();
            }
            return result.ToArray();
        }
    }
}
using System.Collections.Generic;
using ExtensionMethods;

namespace ConsoleApplication
{
    public class ListMaker
    {   
        DataObject data = new DataObject();
        public string[] CreateTable(string[] array, string type)
        {
            TableMaker table = new TableMaker();
            int number = 0;
            List<string> result = new List<string>();
            string[] headings = {"", "Name", "Size", "Last Accessed"};
            table.PrintLine();
            table.PrintRow(headings);
            table.PrintLine();

            foreach(string item in array)
            {
                List<string> list = new List<string>();

                number += 1;
                string numberString = number + ".";
                list.Add(numberString);

                string name = ObjectManager.RemovePathFromName(item);
                list.Add(name);

                string size;

                if (type == "file")
                {
                    data.Size = item.FileSize();
                }
                else
                {
                    size = item.FolderSize();
                }

                list.Add(data.size);

                data.LastAccess = ObjectManager.GetTimeStampForLastAccess(item);
                list.Add(data.LastAccess);

                string[] row = list.ToArray(); 
                result.Add(table.PrintRow(row));
                result.Add(table.PrintLine());
                list.Clear();
            }
            string[] answer = result.ToArray();
            return answer;
        }
    }
}
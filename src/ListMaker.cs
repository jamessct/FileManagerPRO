using System;
using System.Collections.Generic;
using ExtensionMethods;
namespace ConsoleApplication
{
    public class ListMaker
    {   
        DataObject dataObject = new DataObject();
        //FileObject fileObject = new FileObject();
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

                string name = dataObject.RemovePathFromName(item);
                list.Add(name);

                string size;

                if (type == "file")
                {
                    size = item.FileSize();
                }
                else
                {
                    size = item.FolderSize();
                }

                list.Add(size);

                FileObject.LastAccess = dataObject.GetTimeStampForLastAccess(item);
                list.Add(FileObject.LastAccess);

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
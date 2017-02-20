using System;
using System.Collections.Generic;
using ExtensionMethods;
namespace ConsoleApplication
{
    public class ListMaker : AppHelper
    {   
        public string[] CreateTable(string[] array, string type, string input)
        {
            // Console.WriteLine(array);

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

                string name = this.RemovePathFromName(item);
                list.Add(name);

                string size;

                if (type == "file")
                {
                    size = item.FileSize();
                    Console.WriteLine(size);
                }
                else
                {
                    size = item.FolderSize();
                }

                list.Add(size);

                string lastAccess = base.GetTimeStampForLastAccess(item);
                list.Add(lastAccess);

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
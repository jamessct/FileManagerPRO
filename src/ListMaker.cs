using System.Collections.Generic;

namespace ConsoleApplication
{
    public class ListMaker : AppHelper
    {
        public void CreateListTable(string[] array, string type)
        {
            var table = new TableMaker();
            int number = 0;

            string[] headings = {"", "Name", "Size", "Last Accessed"};
            table.PrintLine();
            table.PrintRow(headings);

            foreach (string item in array)
            {
                List<string> list = new List<string>();

                number += 1;
                string numberString = number + ".";
                list.Add(numberString);

                string name = this.RemovePathFromName(item);
                list.Add(name);

                if (type == "file")
                {
                    string size = base.GetSizeOfFile(item);
                    list.Add(size);
                }
                else
                {
                    string size = base.GetSizeOfFileList(item);
                    list.Add(size);
                }

                string lastAccess = base.GetTimeStampForLastAccess(item);
                list.Add(lastAccess);

                string[] listArray = list.ToArray();
                
                table.PrintLine();
                table.PrintRow(listArray);
            }  
            table.PrintLine();
        }
        
        public string RemovePathFromName(string path)
        {
            string subString = AppRunner.userInput;
            int subStringLength = subString.Length;
            string fileName = path;
            fileName = path.Remove(0, subStringLength + 1);
            return fileName;
        }
    }
}
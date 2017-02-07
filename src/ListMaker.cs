using System.Collections.Generic;

namespace ConsoleApplication
{
    public class ListMaker : AppHelper
    {
        public void CreateListTable(string[] array, string type)
        {
            TableMaker table = new TableMaker();
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
                    long size = base.GetSizeOfFile(item);
                    string answer = Utilities.SelectAppropriateFileSizeFormat(size);
                    list.Add(answer);
                }
                else
                {
                    long size = base.GetSizeOfFileList(item);
                    string answer = Utilities.SelectAppropriateFileSizeFormat(size);
                    list.Add(answer);
                }

                string lastAccess = base.GetTimeStampForLastAccess(item);
                list.Add(lastAccess);

                string[] listArray = list.ToArray();
                
                table.PrintLine();
                table.PrintRow(listArray);
            }  
            table.PrintLine();
        }
        
        private string RemovePathFromName(string path)
        {
            string subString = Options.input;
            int subStringLength = subString.Length;
            string fileName = path;
            fileName = path.Remove(0, subStringLength + 1);
            return fileName;
        }
    }
}
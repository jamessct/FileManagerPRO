using System.Collections.Generic;

namespace ConsoleApplication
{
    public class ListMaker : AppHelper
    {   
        public string[] CreateTable(string[] array, string type, string input)
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

                string name = this.RemovePathFromName(item, input);
                list.Add(name);

                long size;

                if (type == "file")
                {
                    size = base.GetSizeOfFile(item);
                }
                else
                {
                    size = base.GetSizeOfFileList(item);
                }

                string fileSize = Utilities.SelectAppropriateFileSizeFormat(size);
                list.Add(fileSize);

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

        public string RemovePathFromName(string path, string input)
        {
            string subString = input;
            int subStringLength = subString.Length;
            string fileName = path;
            fileName = path.Remove(0, subStringLength + 1);
            return fileName;
        }
    }
}
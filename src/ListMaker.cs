using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class ListMaker : AppHelper
    {
        public void ListSubfoldersInDirectory()
        {
            base.ListSubfoldersInDirectory(AppRunner.userInput);
        }

        public void ListFilesInDirectory()
        {
            var table = new TableMaker();
            string[] files = base.ListFilesInDirectory(AppRunner.userInput);
            int number = 0;

            string[] headings = {"", "File Name", "File Size", "Last Accessed"};

            table.PrintLine();
            table.PrintRow(headings);

            foreach (string file in files)
            {
                List<string> list = new List<string>();
                
                
                number += 1;
                string numberString = number + ".";
                list.Add(numberString);
                
                list.Add(file);

                string fileSize = base.GetSizeOfFile(file); 
                list.Add(fileSize);

                string lastAccess = base.GetTimeStampForLastAccess(file);
                list.Add(lastAccess);

                string[] listArray = list.ToArray();
                
                table.PrintLine();
                table.PrintRow(listArray);
            }
            table.PrintLine();
            
        }


    }
}
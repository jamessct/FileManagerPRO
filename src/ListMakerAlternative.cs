using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class ListMaker : IStorageItem
    {
        private string name;
        private string size;
        private string lastAccess;
        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Size
        {
            get
            {
                return size;
            }
        }

        public string LastAccessed
        {
            get
            {
                return lastAccess;
            }
        }

        public string[] CreateTable(string Name, string Size, string LastAccessed)
        {
            TableMaker table = new TableMaker();
            int number = 0;
            List<string> result = new List<string>();
            string[] headings = {"", "Name", "Size", "Last Accessed"};
            table.PrintLine();
            table.PrintRow(headings);
            table.PrintLine();

            throw new ArgumentException();
        }
    }
}
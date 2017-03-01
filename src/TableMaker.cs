using System;

namespace ConsoleApplication
{
    public class TableMaker
    {
        int tableWidth;

        public TableMaker()
        {
            tableWidth = 110;
        }

        public string PrintLine()
        {
            return new string('-', tableWidth);
        }

        public string PrintRow(string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach(string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            return row;
        }

        private string AlignCentre(string text, int width)
        {
            text = (text.Length > width ? text.Substring(0, width - 3) + "..." : text);

            if(string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        public void PrintTableToConsole(string[] table)
        {
            foreach (string row in table)
            {
                Console.WriteLine(row);
            }
        }
    }
}
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
           Console.WriteLine(new string('-', tableWidth));
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

            Console.WriteLine(row);
            return row;
        }

        private string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if(string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
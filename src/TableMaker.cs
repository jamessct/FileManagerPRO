using System;

namespace ConsoleApplication
{
    public class TableMaker : AppHelper
    {

        // static int tableWidth = 80;

        // public static void PrintLine()
        // {
        //    Console.WriteLine(new string('-', tableWidth));
        // }

        // public static void PrintRow(params string[] columns)
        // {
        //     int width = (tableWidth - columns.Length) / columns.Length;
        //     string row = "|";

        //     foreach(string column in columns)
        //     {
        //         row += AlignCentre(column, width) + "|";
        //     }

        //     Console.WriteLine(row);
        // }

        // public static string AlignCentre(string text, int width)
        // {
        //     text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

        //     if (string.IsNullOrEmpty(text))
        //     {
        //         return new string(' ', width);
        //     }
        //     else
        //     {
        //         return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        //     }
        // }



        public void CheckFolderExists(string folderPath)
        {
            base.CheckFolderExists(folderPath);
        }

        
    }
}
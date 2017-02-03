using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            Console.Title = "File Manager PRO 2.0";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to File Manager PRO! To proceed, please select a number from the list below:");
            Console.WriteLine();
            ListMaker list = new ListMaker();
            string[] mainMenu = {"Get list of files in directory", "Get list of folders in directory", "Manage files", "Manage folders", "Generate index file"};
            
            AppRunner.Menu(mainMenu, "To quit, press 'Q'.", 1);  
        }
    }
}
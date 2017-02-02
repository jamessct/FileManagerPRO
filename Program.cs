using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            Console.Title = "File Manager PRO v1.0.0";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to File Manager Pro! To proceed, please select a number from the list below:");
            Console.WriteLine();
            ListMaker list = new ListMaker();
            var app = new AppRunner();
            // string[] mainMenu = {"Get size of file", "Get size of directory", "List files in directory", "Manage files", "Manage folders", "Create index file", "Get list of subfolders"};
            
            app.Menu(AppRunner.mainMenu, "To quit, press 'Q'.", 1);  
        }
    }
}
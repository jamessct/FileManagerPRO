using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            Console.Clear();
            Console.Title = "File Manager PRO 2.0";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   ___ _ _                                                     ___  __    ___   ____    ___  ");
            Console.WriteLine("  / __(_) | ___    /\\/\\   __ _ _ __   __ _  __ _  ___ _ __    / _ \\/__\\  /___\\ |___ \\  / _ \\ ");
            Console.WriteLine(" / _\\ | | |/ _ \\  /    \\ / _` | '_ \\ / _` |/ _` |/ _ \\ '__|  / /_)/ \\// //  //   __) || | | |");
            Console.WriteLine("/ /   | | |  __/ / /\\/\\ \\ (_| | | | | (_| | (_| |  __/ |    / ___/ _  \\/ \\_//   / __/ | |_| |");
            Console.WriteLine("\\/    |_|_|\\___| \\/    \\/\\__,_|_| |_|\\__,_|\\__, |\\___|_|    \\/   \\/ \\_/\\___/   |_____(_)___/ ");
            Console.WriteLine("                                           |___/                                             ");;
            Console.WriteLine("Welcome to File Manager PRO! To proceed, please select a number from the list below:");
            Console.WriteLine();

            MenuExperiments menu = new MenuExperiments();
            string[] mainMenu = {"Get list of files in directory", "Get list of folders in directory", "Manage files", "Manage folders", "Generate index file"};
            menu.DynamicMenu(mainMenu);

            IRunable run = new AppRunner();
            // run.Menu(Options.mainMenu, Options.quit, 1);  
        }
    }
}
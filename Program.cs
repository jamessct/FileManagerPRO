using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            Console.Clear();
            Console.Title = "File Manager PRO 2.1";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   ___ _ _                                                     ___  __    ___   ____    ___  ");
            Console.WriteLine("  / __(_) | ___    /\\/\\   __ _ _ __   __ _  __ _  ___ _ __    / _ \\/__\\  /___\\ |___ \\  / _ \\ ");
            Console.WriteLine(" / _\\ | | |/ _ \\  /    \\ / _` | '_ \\ / _` |/ _` |/ _ \\ '__|  / /_)/ \\// //  //   __) || | | |");
            Console.WriteLine("/ /   | | |  __/ / /\\/\\ \\ (_| | | | | (_| | (_| |  __/ |    / ___/ _  \\/ \\_//   / __/ | |_| |");
            Console.WriteLine("\\/    |_|_|\\___| \\/    \\/\\__,_|_| |_|\\__,_|\\__, |\\___|_|    \\/   \\/ \\_/\\___/   |_____(_)___/ ");
            Console.WriteLine("                                           |___/                                             ");
            Console.WriteLine("Welcome to File Manager PRO! To proceed, select an option from the menu below using the UP and DOWN arrow keys to navigate:");
            Console.WriteLine();

            DynamicMenu.Menu(DynamicMenu.mainMenu, 1);            
        }
    }
}
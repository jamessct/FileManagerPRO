using System;
using System.Threading;

namespace ConsoleApplication
{
    public class AppRunner : IRunable
    {
        public string menu;
        public string quit;
        
        public AppRunner()
        {
            menu = "Press 'M' to access the MAIN MENU.";
            quit = "Press 'Q to quit.";
        }
        
        void IRunable.Menu(string[] array, string back, int menu)
        {

            Console.ForegroundColor = ConsoleColor.White;

            int number = 0;

            foreach(string item in array)
            {
                number += 1;
                Console.WriteLine(number + ". " + item);
            }

            Console.WriteLine(back);
            char response = Console.ReadKey().KeyChar;
            Console.WriteLine();
            
            ConsoleAnimation spin = new ConsoleAnimation();
            bool check = true;
            
            while(check == true)
            {
                Thread.Sleep(30);
                check = spin.animation();
            }

            Console.WriteLine();

            switch(menu)
            {
                case 1:
                {
                    Options.MainMenuOptions(response);
                    break;
                }
                case 2:
                {
                    Options.ManageFiles(response);
                    break;
                }
                case 3:
                {
                    Options.ManageFolders(response);
                    break;
                }
            }
        }
    }
}
using System;
using System.Threading;

namespace ConsoleApplication
{
    public class DynamicMenu
    {
        public string[] mainMenu = {"Get list of files in directory", "Get list of folders in directory", "Manage files", "Manage folders", "Generate index file", "Quit" };
        public void Menu(string[] array, int menu)
        {
            bool loopComplete = false;
            int topOffset = Console.CursorTop;
            int bottomOffset = 0;
            int selectedItem = 0;
            ConsoleKeyInfo key;

            Console.CursorVisible = false;

            //Console.WriteLine("testing");

            while(!loopComplete)
            {
                for (int i = 0; i < array.Length; i ++)
                {
                    if (i == selectedItem)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine(array[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(array[i]);
                    }
                }
                bottomOffset = Console.CursorTop;

                key = Console.ReadKey(true);

                switch(key.Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        if(selectedItem > 0)
                        {
                            selectedItem--;
                        }
                        else
                        {
                            selectedItem = (array.Length - 1);
                        }
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        if (selectedItem < (array.Length - 1))
                        {
                            selectedItem++;
                        }
                        else
                        {
                            selectedItem = 0;
                        }
                        break;
                    }
                    case ConsoleKey.Enter:
                    {
                        Console.WriteLine("testing");
                        loopComplete = true;
                        break;
                    }
                }
                Console.SetCursorPosition(0, topOffset);
            }
            Console.SetCursorPosition(0, bottomOffset);
            Console.CursorVisible = true;

            ConsoleAnimation spin = new ConsoleAnimation();
            bool check = true;

            while(check == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Thread.Sleep(30);
                check = spin.animation();
            }
             selectOptions(selectedItem, menu);
        }

        public void selectOptions(int selectedItem, int menu)
        {
            switch(menu)
            {
                case 1:
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("MAIN MENU");
                    Console.WriteLine();
                    Options.MainMenuOptions(selectedItem);
                    break;
                }
                case 2:
                {
                    Console.WriteLine("testing");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FILE MANAGER");
                    Console.WriteLine("testing1");
                    Console.WriteLine();
                    Options.ManageFiles(selectedItem);
                    break;
                }
                case 3:
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FOLDER MANAGER");
                    Console.WriteLine();
                    Options.ManageFolders(selectedItem);
                    break;
                }
            }
        }
    }
}
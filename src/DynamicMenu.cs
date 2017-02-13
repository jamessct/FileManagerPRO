using System;

namespace ConsoleApplication
{
    
    public class DynamicMenu
    {
        public void Menu(string[] inArray, int menu)
        {
            bool loopComplete = false;
            int topOffset = Console.CursorTop;
            int bottomOffset = 0;
            int selectedItem = 0;
            ConsoleKeyInfo key;

            Console.CursorVisible = false;

            while (!loopComplete)
            {
                for (int i = 0; i < inArray.Length; i ++)
                {
                    if (i == selectedItem)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("-" + inArray[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("-" + inArray[i]);
                    }
                }
                bottomOffset = Console.CursorTop;

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        if (selectedItem > 0)
                        {
                            selectedItem--;
                        }
                        else
                        {
                            selectedItem = (inArray.Length - 1);
                        }
                        break;
                    }

                    case ConsoleKey.DownArrow:
                    {
                        if (selectedItem < (inArray.Length - 1))
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
                        loopComplete = true;
                        break;
                    }
                }
                Console.SetCursorPosition(0, topOffset);
            }
            Console.SetCursorPosition(0, bottomOffset);
            Console.CursorVisible = true;
            
            selectOptions(selectedItem, menu);
        }  

        public void selectOptions(int selectedItem, int menu)
        {
            switch(menu)
            {
                case 1:
                {
                    Options.MainMenuOptions(selectedItem);
                    break;
                }
                case 2:
                {
                    Options.ManageFiles(selectedItem);
                    break;
                }
                case 3:
                {
                    Options.ManageFolders(selectedItem);
                    break;
                }
            }
                  
            
        }    
    }
}
        
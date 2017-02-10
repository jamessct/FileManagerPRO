using System;

namespace ConsoleApplication
{
    
    public class MenuExperiments
    {
        public int DynamicMenu(string[] inArray)
        {
            bool loopComplete = false;
            int number = 0;
            int topOffset = Console.CursorTop;
            int bottomOffset = 0;
            int selectedItem = 0;
            ConsoleKeyInfo kb;

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

                kb = Console.ReadKey(true);

                switch (kb.Key)
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
            return selectedItem;
        }      
    }
}
        
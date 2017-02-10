using System;

namespace ConsoleApplication
{
    
    public class NewMenu
    {
        // public void MenuExperiment1()
        // {
        //     Console.Clear();
        //     Console.WriteLine("Option 1");
        //     Console.WriteLine("Option 2");
        //     Console.WriteLine("Option 3");
        //     Console.WriteLine();

        //     var originalpos = Console.CursorTop;

        //     var key = Console.ReadKey();
        //     var i = 1;

        //     while (key.KeyChar != 'q')
        //     {          

        //         if (key.Key == ConsoleKey.UpArrow)
        //         {
                    
        //             Console.SetCursorPosition(0, Console.CursorTop - i);
        //             Console.ForegroundColor = ConsoleColor.Cyan;
        //             Console.BackgroundColor = ConsoleColor.White;
        //             Console.WriteLine("Option " + (Console.CursorTop + 1));
        //             Console.ResetColor();
        //             i++;

        //         }

        //         if (key.Key == ConsoleKey.DownArrow)
        //         {
        //             Console.SetCursorPosition(0, Console.CursorTop + i);
        //             Console.ForegroundColor = ConsoleColor.Cyan;
        //             Console.BackgroundColor = ConsoleColor.White;
        //             Console.WriteLine("Option " + (Console.CursorTop - 1));
        //             Console.ResetColor();
        //             i--;
        //         }

        //         Console.SetCursorPosition(8, originalpos);
        //         key = Console.ReadKey();
            
        //     }
        // }

        public int MenuExperiment2(string[] inArray)
        {
            bool loopComplete = false;
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
        
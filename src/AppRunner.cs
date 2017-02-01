using System;
using System.Threading;

namespace ConsoleApplication
{
    public class AppRunner
    {
        AppHelper app = new AppHelper();
        string[] mainMenu = {"Get size of file", "Get size of directory", "List files in directory", "Manage files", "Manage folders", "Create index file"};
        string[] filesMenu = { "Create file", "Delete file", "Move file", "Read text from file", "Write text to file", "Search file for text" };
        string[] foldersMenu = {"Create folder", "Delete folder"};
        string quit = "Press 'Q' to quit.";
        string menu = "Press 'M' to return to the main menu.";
        
        public void Menu(string[] array, string back, int menu)
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
                    this.MainMenuOptions(response);
                    break;
                }
                case 2:
                {
                    this.ManageFiles(response);
                    break;
                }
                case 3:
                {
                    this.ManageFolders(response);
                    break;
                }
            }
        }

        public void MainMenuOptions(char response)
        {
            switch(response)
            {
                case '1':
                {
                    Console.WriteLine("Please enter the file path to get the size of the file:");
                    string input = Console.ReadLine();

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("This file is: " + app.GetSizeOfFile(input));
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Invalid user input!");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                }  
                case '2':
                {
                    Console.WriteLine("Please enter a directory path to get the size of the directory: ");
                    string input = Console.ReadLine();

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green; 
                        Console.WriteLine("The total size of the files within this folder (excluding subfolders) is: " + app.GetSizeOfFileList(input));
                        Console.WriteLine("The total size of this directory (including subfolders contained within) is: " + app.GetSizeOfDirectory(input));
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Invalid user input!");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }   
                }  
                case '3':
                {
                    Console.WriteLine("Please enter a directory path: ");
                    string input = Console.ReadLine();
                    
                    try
                    {
                        var answer = app.ListFilesInDirectory(input);
                        string answerStringified = app.ConvertStringToArray(answer);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(answerStringified);
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Invalid user input!");
                        this.Menu(mainMenu, "To quit, press 'Q'", 1);
                        break;
                    }
                }   
                case '4':
                {
                    Console.WriteLine("FILE MANAGER");
                    this.Menu(filesMenu, menu, 2);
                    break;
                }
                case '5':
                {
                    Console.WriteLine("FOLDER MANAGER");
                    this.Menu(foldersMenu, menu, 3);
                    break;
                }
                case '6':
                {
                    Console.WriteLine("This option creates a text file which compiles information on all ofthe files in the location specified.");
                    Console.WriteLine("To continue, please enter the directory path where you would like to create your index file:");
                    string input = Console.ReadLine();

                    try
                    {
                        app.CreateIndexFile(input);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SUCCESS! Your new index file has been created at " + input + "\\index.txt");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Invalid user input!");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                }
                case 'q':
                {
                    Console.WriteLine();
                    Console.WriteLine("GOODBYE!");
                    Environment.Exit(0);
                    break;
                }
                default:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command! Please try again.");
                    this.Menu(mainMenu, quit, 1);
                    break;
                }
            }
        }
            
        public void ManageFiles(char response)
        {
            switch(response)
            {
                //CreateFile
                case '1':
                {
                    Console.WriteLine("Enter the path for the file you wish to create: ");
                    string input = Console.ReadLine();

                    try
                    {
                        if(app.CheckFileExists(input) == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("SUCCESS! Your file has been created.");
                            this.Menu(mainMenu, quit, 1);
                            
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Could not create a file in this location!");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Either the file already exists or you have entered an invalid file path!");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                }
                //Delete File
                case '2':
                {
                    Console.WriteLine("WARNING! This function will permenantly delete the specified file. To cancel, press 'C'.");
                    Console.WriteLine("Enter the path for the file you wish to delete: ");
                    string input = Console.ReadLine();

                    if(input == "c" || input == "C")
                    {
                        this.Menu(filesMenu, menu, 1);
                    }
                        
                    try
                    {
                        app.RemoveFile(input);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SUCCESS! File has been removed");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! This file path does not exist!");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                }
                //Move File
                case '3':
                {
                    Console.WriteLine("Please enter the path of the file that you wish to move: ");
                    string input1 = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Please enter the path you wish to move the file to: ");
                    string input2 = Console.ReadLine();

                    try
                    {
                        app.MoveFile(input1, input2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Operation successful!");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The file you are trying to move doesn't exist!");
                        this.Menu(mainMenu, "To quit, press 'Q'", 1);
                        break;
                    } 
                }
                //Read text from file
                case '4':
                {
                    Console.WriteLine("Select file to read: ");
                    string input = Console.ReadLine();

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(app.ReadTextFromFile(input));
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The file you are trying to read doesn't exist!");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                    
                }
                //Write text to file
                case '5':
                {
                    Console.WriteLine("Select file to write to:");
                    string input1 = Console.ReadLine();
                    Console.WriteLine("Enter the text to write to the file:");
                    string input2 = Console.ReadLine();

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        app.WriteTextToFile(input1, input2);
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The file you are trying to write to doesn't exist!");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }  
                }
                //search file for text
                case '6':
                {
                    Console.WriteLine("Select file to search:");
                    string input1 = Console.ReadLine();
                    Console.WriteLine("Enter the text to search for:");
                    string input2 = Console.ReadLine();
                    
                    try
                    {
                        if(app.SearchForTextInFile(input1, input2) == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(input1 + " includes the phrase '" + input2 + "'");
                            this.Menu(mainMenu, quit, 1);
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(input1 + " does NOT contain the phrase '" + input2 + "'");
                        this.Menu(mainMenu, quit, 1);
                        break;  
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! File path cannot be found!");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                }
                //Return to menu
                case 'm':
                {
                    this.Menu(mainMenu, "To quit, press 'Q'", 1);
                    break;
                }
                //else
                default:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command! Please try again.");
                    this.Menu(filesMenu, menu, 2);
                    break;
                }
            }
        }

        public void ManageFolders(char response)
        {
            switch(response)
            {
                //Create Folder
                case '1':
                {
                    Console.WriteLine("Enter the path for the folder you wish to create:");
                    string input = Console.ReadLine();

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        app.CreateNewFolder(input);
                        Console.WriteLine("SUCCESS! New folder created at " + input);
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }

                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The requested directory path is invalid!");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                }
                //Delete Folder
                case '2':
                {
                    Console.WriteLine("WARNING! This function will permenantly delete the specified folder and everything contained within. To cancel, enter 'C'.");
                    Console.WriteLine("Enter the path of the folder you wish to delete:");
                    string input = Console.ReadLine();

                    if(input == "c" || input == "C")
                    {
                        this.Menu(mainMenu, quit, 1);
                    }

                    try
                    {
                        app.RemoveFolder(input, true);

                        if(app.CheckFolderExists(input) == false)
                        {   
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("SUCCESS! The specified folder has been removed.");
                            this.Menu(mainMenu, quit, 1);
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The specified folder could not be removed.");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The folder you are trying to remove does not exist");
                        this.Menu(mainMenu, quit, 1);
                        break;
                    }
                }
                //Return to menu
                case 'm':
                {
                    this.Menu(mainMenu, quit, 1);
                    break;
                }
                //else
                default:
                {
                    Console.WriteLine("Invalid command! Please try again.");
                    this.Menu(foldersMenu, menu, 3);
                    break;
                }
            }
        }
    }
}
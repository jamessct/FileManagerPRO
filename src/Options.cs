using System;

namespace ConsoleApplication
{
    public static class Options
    {
        static IRunable run = new AppRunner();
        static AppHelper app = new AppHelper();    
        public static string input;
        public static string quit;
        public static string menu;
        public static string[] mainMenu = {"Get list of files in directory", "Get list of folders in directory", "Manage files", "Manage folders", "Generate index file"};
        public static string[] filesMenu = {"Create file", "Delete file", "Move file", "Read text from file", "Write text to file", "Search file for text", "Generate index file"};
        public static string[] foldersMenu = {"Create folder", "Delete folder"};
        static Options()
        {
            IRunable run = new AppRunner();
            AppHelper app = new AppHelper();   
            quit = "Press 'Q' to quit.";
            menu = "Press 'M' to return to the MAIN MENU.";
        }

        public static void MainMenuOptions(char response)
        {
            switch(response)
            {
                case '1':
                {
                    Console.WriteLine("Please enter a directory path: ");
                    input = Console.ReadLine();
                    
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        string[] files = app.ListFilesInDirectory(input);
                        Console.WriteLine("input = " + input);
                        ListMaker list = new ListMaker();
                        TableMaker tableMaker = new TableMaker();
                        
                        string[] table = list.CreateTable(files, "file");
                        tableMaker.PrintTableToConsole(table);
                        long listSize = app.GetSizeOfFileList(input);
                        Console.WriteLine("The total size of the files within this folder (excluding subfolders) is: " + Utilities.SelectAppropriateFileSizeFormat(listSize));
                        
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(NullReferenceException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Invalid user input!");
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }   
                }   
                case '2': 
                {
                    Console.WriteLine("Please enter a directory:");
                    input = Console.ReadLine();
                    try
                    {
                        var list = new ListMaker();
                        Console.ForegroundColor = ConsoleColor.Green;
                        string[] folders = app.ListSubfoldersInDirectory(input);
                        list.CreateTable(folders, "folder");
                        long totalSize = app.GetSizeOfDirectory(input) - app.GetSizeOfFileList(input);
                        Console.WriteLine("The total size of the subfolders within this directory is: " + Utilities.SelectAppropriateFileSizeFormat(totalSize));

                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Invalid user input!");
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }  
                }
                case '3':
                {
                    Console.WriteLine("FILE MANAGER");
                    run.Menu(filesMenu, menu, 2);
                    break;
                }
                case '4':
                {
                    Console.WriteLine("FOLDER MANAGER");
                    run.Menu(foldersMenu, menu, 3);
                    break;
                }
                case '5':
                {
                    Console.WriteLine("This option creates a text file which compiles information on all of the files and folders in the location specified.");
                    Console.WriteLine("To continue, please enter the directory path where you would like to create your index file:");
                    input = Console.ReadLine();

                    try
                    {
                        app.CreateIndexFile(input);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SUCCESS! Your new index file has been created at " + input + "\\index.txt");
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Invalid user input!");
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                }
                case 'q':
                {
                    Console.WriteLine("GOODBYE!");
                    Environment.Exit(0);
                    break;
                }
                default:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command! Please try again.");
                    run.Menu(mainMenu, quit, 1);
                    break;
                }
            }
        }

        public static void ManageFiles(char response)
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
                            run.Menu(mainMenu, quit, 1);
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Could not create a file in this location!");
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Either the file already exists or you have entered an invalid file path!");
                        run.Menu(mainMenu, quit, 1);
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
                        run.Menu(filesMenu, menu, 1);
                    }
                        
                    try
                    {
                        app.RemoveFile(input);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SUCCESS! File has been removed");
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! This file path does not exist!");
                        run.Menu(mainMenu, quit, 1);
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
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The file you are trying to move doesn't exist!");
                        run.Menu(mainMenu, quit, 1);
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
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The file you are trying to read doesn't exist!");
                        run.Menu(mainMenu, quit, 1);
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
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The file you are trying to write to doesn't exist!");
                        run.Menu(mainMenu, quit, 1);
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
                            run.Menu(mainMenu, quit, 1);
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(input1 + " does NOT contain the phrase '" + input2 + "'");
                        run.Menu(mainMenu, quit, 1);
                        break;  
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! File path cannot be found!");
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                }
                //Return to menu
                case 'm':
                {
                    run.Menu(mainMenu, quit, 1);
                    break;
                }
                //else
                default:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command! Please try again.");
                    run.Menu(filesMenu, menu, 2);
                    break;
                }
            }
        }

        public static void ManageFolders(char response)
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
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }

                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The requested directory path is invalid!");
                        run.Menu(mainMenu, quit, 1);
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
                        run.Menu(mainMenu, quit, 1);
                    }

                    try
                    {
                        app.RemoveFolder(input, true);

                        if(app.CheckFolderExists(input) == false)
                        {   
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("SUCCESS! The specified folder has been removed.");
                            run.Menu(mainMenu, quit, 1);
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The specified folder could not be removed.");
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The folder you are trying to remove does not exist");
                        run.Menu(mainMenu, quit, 1);
                        break;
                    }
                }
                //Return to menu
                case 'm':
                {
                    run.Menu(mainMenu, quit, 1);
                    break;
                }
                //else
                default:
                {
                    Console.WriteLine("Invalid command! Please try again.");
                    run.Menu(foldersMenu, menu, 3);
                    break;
                }
            }
        }
    }
}
namespace ConsoleApplication
{
    public class ListMaker : AppHelper
    {
        public void ListSubfoldersInDirectory()
        {
            base.ListSubfoldersInDirectory(AppRunner.userInput);

        }

        public string[] ListFilesInDirectory()
        {
            string[] files = base.ListFilesInDirectory(AppRunner.userInput);
            int number = 0;

            foreach (string file in files)
            {
                number += 1;
                fil
                string fileSize = base.GetSizeOfFile(file);
                
            }

            return files;
        }
    }
}
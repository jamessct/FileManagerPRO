namespace ConsoleApplication
{
    interface IStorageItem
    {
        string Path
        {
            get;
        }

       string Name
       {
           get;
       }

       string Size
       {
           get;
       }

       string LastAccess
       {
           get;
       }
    }
}
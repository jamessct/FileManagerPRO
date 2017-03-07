namespace ConsoleApplication
{
    interface IStorageItem
    {
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
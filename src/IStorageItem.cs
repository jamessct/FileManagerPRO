namespace ConsoleApplication
{
    interface IStorageItem
    {
        string Path{ get;set; }
        string Name{ get;set; }
        string Size { get;set; }
        string LastAccess { get;set; }
    }
}
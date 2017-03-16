using ExtensionMethods;

namespace ConsoleApplication
{
    public class FolderObject : DataObject
    {
        public string size;
        public override string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = Path.FolderSize();
            }
        }
    }  
}
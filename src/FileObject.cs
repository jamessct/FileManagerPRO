using ExtensionMethods;

namespace ConsoleApplication
{
    public class FileObject : DataObject
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
                size = Path.FileSize();
            }
        }
    }
}
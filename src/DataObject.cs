namespace ConsoleApplication
{
    public class DataObject
    {
        //Name

        //Size

        //LastAccess
        public string name;
        public string size;
        public string lastAccess;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        public string LastAccess
        {
            get
            {
                return lastAccess;
            }
            set
            {
                lastAccess = value;
            }
        }
    }
}
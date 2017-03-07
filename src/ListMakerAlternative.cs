using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication
{
    public class ListMaker2 : IStorageItem
    {
        private string name;
        private string size;
        private string lastAccess;
        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Size
        {
            get
            {
                return size;
            }
        }

        public string LastAccess
        {
            get
            {
                return lastAccess;
            }
        }

        DataObject dataObject = new DataObject();


    }
}
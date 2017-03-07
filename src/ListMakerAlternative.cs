using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class ListMaker2 
    {
        DataObject dataObject = new DataObject();

        public string[] CreateTable(List<DataObject> ObjectList)
        {
            //Gets called to take in a list of Objects containing:
            // - Name
            // - Size
            // - Last Accessed
            //... and converts them into the final intended string format

            foreach (var Object in ObjectList)
            {

            }

            throw new Exception("test");
        }
    }
}
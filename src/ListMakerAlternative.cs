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

            //NOTE: THIS PROBABLY WON'T WORK AS YOU ARE CREATING A NEW
            //INSTANCE OF THE DATAOBJECT CLASS TO ALLOW CREATETABLE TO TAKE
            //A LIST OF THIS SORT AS A PARAMETER, BUT THIS WILL BE DISTINCT
            //WHERE YOU CALL IT.  
            //IF IT DOES WORK, THEN CONSIDER BYPASSING THIS METHOD ALTOGETHER

            throw new Exception("test");
        }
    }
}
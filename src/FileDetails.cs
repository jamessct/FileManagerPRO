using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class FileDetails
    {
        List<string> FileList = new List<string>();
        public List<string> FileListMaker(string Name, string Size, string LastAccess)
        {
            
            throw new ArgumentException("temp");
        }
    }
}


// using System;
// using System.Collections.Generic;

// namespace ConsoleApplication
// {
//     public class FileDetails
//     {
//         public List<string> FileDetailsList(FileDetails ListMaker)
//         //Create method to generate list
//         {
//             //make list
//             var details = new ListMaker();

//             //loop through 
//             foreach(var data in DataObject)
//             {
//                 FileObject.Add(new FileDetails(data.Name));
//             }

//             return details;
//         }
//         /* This file should contain raw info needed for the list, i.e. Name, Size, and Last Accessed. */
//     }
// }
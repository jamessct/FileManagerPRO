using System;
using System.Collections.Generic;
using ConsoleApplication;
using ExtensionMethods;
using Xunit;

namespace MyApp
{
    public class ListMakerTheoryTest
    {
        [Theory]
        [InlineDataAttribute(0, new string[] {@"c:\Projects\Tests\IndexTests\index.txt", @"c:\Projects\Tests\IndexTests\test1.txt", @"c:\Projects\Tests\IndexTests\test2.txt"})]
        public void CanCreateArrayOfFilesForTable(int no, string[] files)
        {
            //Assign
            ListMaker list = new ListMaker();
            List<DataObject> fileList = new List<DataObject>();
            
            foreach (string file in files)
            {
                DataObject item = new DataObject();
                item.Path = file;
                item.Name = file.Name();
                item.Size = file.Size();
                item.LastAccess = file.LastAccess();
                fileList.Add(item);
            }

            int expectedResult = 6;
            
            //Act
            string[] result = list.CreateTable(fileList);
            int answer = result.Length;

            //Assert
            Assert.Equal(expectedResult, answer);
        }

        [Theory]
        [InlineDataAttribute(0, new string[] {@"c:\Projects", @"c:\Vision Australia", @"c:\EmptyFolder"})]
        public void CanCreateArrayOfFoldersForTable(int no, string[] folders)
        {
            //Assign
            ListMaker list = new ListMaker();
            List<DataObject> folderList = new List<DataObject>();

            foreach (string folder in folders)
            {
                DataObject item = new DataObject();
                item.Path = folder;
                item.Name = folder.Name();
                item.Size = folder.Size();
                item.LastAccess = folder.LastAccess();
                folderList.Add(item);
            }

            int expectedResult = 6;

            //Act
            string[] result = list.CreateTable(folderList);
            int answer = result.Length;

            //Assert
            Assert.Equal(answer, expectedResult);
        }
    }
}
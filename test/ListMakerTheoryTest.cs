using ConsoleApplication;
using System.Collections.Generic;
using Xunit;

namespace MyApp
{
    public class ListMakerTheoryTest
    {
        [Theory]
        [InlineDataAttribute(new string[] {@"c:\Projects\Tests\IndexTests\index.txt", @"c:\Projects\Tests\IndexTests\test1.txt", @"c:\Projects\Tests\IndexTests\test2.txt"}, @"c:\Projects\Tests")]
        public void CanCreateArrayOfFilesForTable(string[] files, string input)
        {
            //Assign
            ListMaker list = new ListMaker();
            List<DataObject> fileList = new List<DataObject>();
            int expectedArrayLength = 6;
            
            //Act
            string[] result = list.CreateTable(fileList);
            int answer = result.Length;

            //Assert
            Assert.Equal(expectedArrayLength, answer);
        }
    }
}
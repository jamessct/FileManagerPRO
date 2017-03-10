using ConsoleApplication;
using System.Collections.Generic;
using Xunit;

namespace MyApp
{
    public class ListMakerTheoryTest
    {
        [Theory]
        [InlineDataAttribute(new string[] {@"c:\Projects\Tests\IndexTests\index.txt", @"c:\Projects\Tests\IndexTests\test1.txt", @"c:\Projects\Tests\IndexTests\test2.txt"}, "file", @"c:\Projects\Tests")]
        public void CanCreateArrayOfFilesForTable(List<DataObject> fileList, string input)
        {
            //Assign
            ListMaker list = new ListMaker();
            int expectedArrayLength = 6;
            //Act
            string[] result = list.CreateTable(fileList);
            int answer = result.Length;

            //Assert
            Assert.Equal(expectedArrayLength, answer);
        }
    }
}
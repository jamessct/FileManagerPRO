using ConsoleApplication;
using Xunit;

namespace MyApp
{
    public class ListMakerTheoryTest
    {
        // [Theory]
        // [InlineDataAttribute(@"c:\Projects\Tests\index.txt")]
        // public void CanRemovePathFromName(string filePath)
        // {
        //     //Assign
        //     ListMaker list = new ListMaker();
        //     string expected = "index.txt";

        //     //Act
        //     string result = list.RemovePathFromName(filePath);

        //     //Assert
        //     Assert.Equal(expected, result);
        // }

        [Theory]
        [InlineDataAttribute(new string[] {@"c:\Projects\Tests\IndexTests\index.txt", @"c:\Projects\Tests\IndexTests\test1.txt", @"c:\Projects\Tests\IndexTests\test2.txt"}, "file", @"c:\Projects\Tests")]
        public void CanCreateArrayOfFilesForTable(string[] array, string type, string input)
        {
            //Assign
            ListMaker list = new ListMaker();
            int expectedArrayLength = 6;
            //Act
            string[] result = list.CreateTable(array, type);
            int answer = result.Length;

            //Assert
            Assert.Equal(expectedArrayLength, answer);
        }
    }
}
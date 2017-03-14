using ConsoleApplication;
using ExtensionMethods;
using Xunit;

namespace MyApp
{
    public class DataObjectTheoryTest
    {
        [Theory]
        [InlineDataAttribute(@"c:\Projects\index.txt")]
        public void CanSetPathOfDataObejct(string filePath)
        {
            //Assign
            DataObject file = new DataObject();
            string expectedResult = @"c:\Projects\index.txt";

            //Act
            file.Path = filePath;
            string result = file.Path;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\index.txt")]
        public void CanGetNameOfDataObject(string filePath)
        {
            //Assign
            DataObject file = new DataObject();
            string expectedResult = "index.txt";

            //Act
            file.Name = filePath.Name();
            string result = file.Name;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\index.txt")]
        public void CanGetSizeOfFile(string filePath)
        {
            //Assign
            DataObject file = new DataObject();
            string expectedResult = "2.92KB";

            //Act
            file.Size = filePath.FileSize();
            string result = file.Size;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests")]
        public void CanGetSizeOfFolder(string folderPath)
        {
            //Assign
            DataObject folder = new DataObject();
            string expectedResult = "4.35KB";

            //Act
            folder.Size = folderPath.FolderSize();
            string result = folder.Size;

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
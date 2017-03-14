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
        public void CanSetNameOfDataObject(string filePath)
        {
            //Assign
            DataObject file = new DataObject();
            string expectedResult = "index.txt";

            //Act
            file.Path = filePath;
            file.Name = filePath.Name();
            string result = file.Name;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Vision Australia")]
        public void CanSetSizeOfObject(string folderPath)
        {
            //Assign
            DataObject folder = new DataObject();
            string expectedResult = "1.12MB";
            folder.Path = folderPath;
            //Act
            folder.Size = folderPath.Size();
            string result = folderPath.Size();

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\testFile.cs")]
        public void CanSetLastAccessOfDataObject(string path)
        {
            //Assign
            DataObject file = new DataObject();
            file.Path = path;
            string expectedResult = "2017/03/01 12:10:24.96";

            //Act

            file.LastAccess = path.LastAccess();
            string result = file.LastAccess;

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
using ConsoleApplication;
using ExtensionMethods;
using Xunit;

namespace MyApp
{
    public class FileObjectTheoryTest
    {
        [Theory]
        [InlineDataAttribute(@"c:\Projects\index.txt")]
        public void CanSetPathOfFileObject(string filePath)
        {
            //Assign
            DataObject file = new FileObject();
            string expectedResult = @"c:\Projects\index.txt";

            //Act
            file.Path = filePath;
            string result = file.Path;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\index.txt")]
        public void CanSetNameOfFileObject(string filePath)
        {
            //Assign
            DataObject file = new FileObject();
            string expectedResult = "index.txt";

            //Act
            file.Path = filePath;
            file.Name = filePath.Name();
            string result = file.Name;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\testFile.cs")]
        public void CanSetSizeOfFileObject(string filePath)
        {
            //Assign
            DataObject file = new FileObject();
            file.Path = filePath;
            string expectedResult = "0KB";

            //Act
            file.Size = filePath.FileSize();
            string result = file.Size;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\testFile.cs")]
        public void CanSetLastAccessOfFileObject(string filePath)
        {
            //Assign
            DataObject file = new FileObject();
            file.Path = filePath;
            string expectedResult = "2017/03/01 12:10:24.96";

            //Act
            file.LastAccess = filePath.LastAccess();
            string result = file.LastAccess;

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
using ExtensionMethods;
using Xunit;

namespace MyApp
{
    public class ExtensionsTheoryTest
    {
        [Theory]
        [InlineDataAttribute(@"c:\Projects\index.txt")]
        public void CanGetNameOfObject(string path)
        {
            //Assign
            string expectedResult = "index.txt";

            //Act
            string fileName = path.Name();

            //Assert
            Assert.Equal(fileName, expectedResult);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test4.txt")]
        public void CanGetSizeOfFile(string filePath)
        {
            //Assign
            string expectedResult = "0.01KB";

            //Act
            string fileSize = filePath.FileSize();

            //Assert
            Assert.Equal(expectedResult, fileSize);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Program Files (x86)\Wolfenstein - Enemy Territory")]
        public void CanGetSizeOfFolder(string folderPath)
        {
            //Assign
            string expectedResult = "544.43MB";

            //Act
            string folderSize = folderPath.FolderSize();

            //Assert
            Assert.Equal(expectedResult, folderSize);

        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\index.txt")]
        public void CanGetTimeStampForLastAccess(string path)
        {
            //Assign
            string expectedResult = "2017/01/31 11:08:16.12";

            //Act
            string lastAccess = path.LastAccess();

            //Assert
            Assert.Equal(lastAccess, expectedResult);
        }
    }
}
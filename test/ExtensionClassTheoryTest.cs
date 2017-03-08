using ExtensionMethods;
using Xunit;

namespace MyApp
{
    public class ExtensionsTheoryTest
    {
        [Theory]
        [InlineDataAttribute(@"c:\Projects\index.txt")]
        public void CanGetFileName(string path)
        {
            //Assign
            string expectedResult = "index.txt";

            //Act
            string fileName = path.FileName();

            //Assert
            Assert.Equal(fileName, expectedResult);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test4.txt")]
        public void CanGetFileSize(string path)
        {
            //Assign
            string expected = "0.01KB";
            string fileSize;

            //Act
            fileSize = path.FileSize();

            //Assert
            Assert.Equal(expected, fileSize);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Logs")]
        public void CanGetFolderSize(string path)
        {
            //Assign
            string expected = "16.2MB";
            string folderSize;

            //Act
            folderSize = path.FolderSize();

            //Assert
            Assert.Equal(expected, folderSize);
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
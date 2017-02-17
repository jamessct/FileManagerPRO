using ConsoleApplication;
using ExtensionMethods;
using Xunit;

namespace MyApp
{
    public class FileExtensionsTheoryTest
    {
        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test1.txt")]
        public void CanGetFileSize(string path)
        {
            //Assign
            string expected = "0KB";
            string fileSize;

            //Act
            fileSize = path.FileSize();

            //Assert
            Assert.Equal(expected, fileSize);
        }
    }
}
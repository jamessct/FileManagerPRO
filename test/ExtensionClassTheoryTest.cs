using ExtensionMethods;
using Xunit;

namespace MyApp
{
    public class ExtensionsTheoryTest
    {
        [Theory]
        [InlineDataAttribute(@"c:\Projects\index.txt")]
        public void CanGetObjectName(string path)
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
        public void CanGetSizeOfObject(string path)
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
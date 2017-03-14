using ConsoleApplication;
using ExtensionMethods;
using Xunit;

namespace MyApp
{
    public class FolderObjectTheoryTest
    {
        [Theory]
        [InlineDataAttribute(@"c:\Projects")]
        public void CanSetPathOfFolderObject(string folderPath)
        {
            //Assign
            DataObject folder = new FolderObject();
            string expectedResult = @"c:\Projects";

            //Act
            folder.Path = folderPath;
            string result = folderPath;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects")]
        public void CanSetNameOfFolderObject(string folderPath)
        {
            //Assign
            DataObject folder = new FolderObject();
            string expectedResult = "Projects";
            
            //Act
            folder.Path = folderPath;
            folder.Name = folderPath.Name();
            string result = folder.Name;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Vision Australia")]
        public void CanSetSizeOfFolderObject(string folderPath)
        {
            //Assign 
            DataObject folder = new FolderObject();
            string expectedResult = "1.12MB";
            folder.Path = folderPath;

            //Act
            folder.Size = folderPath.FolderSize();
            string result = folder.Size;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Vision Australia")]
        public void CanSetLastAccessOfFolderObject(string folderPath)
        {
            //Assign
            DataObject folder = new FolderObject();
            folder.Path = folderPath;
            string expectedResult = "2017/01/23 09:41:06.75";
            
            //Act
            folder.LastAccess = folderPath.LastAccess();
            string result = folder.LastAccess;

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
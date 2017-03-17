using System;
using System.IO;
using Xunit;
using ConsoleApplication;
using ExtensionMethods;

namespace MyApp
{
    public class TestFixture 
    {
        public TestFixture()
        {
            File.Delete(@"c:\Projects\Tests\test1.txt");
            File.Create(@"c:\Projects\Tests\test2.txt");
            FileStream f1 = File.Create(@"c:\Projects\Tests\MoveFile.txt");
            f1.Dispose();
            File.Delete(@"c:\Projects\Tests\Test4\MovedFile.txt");
            FileStream f2 = File.Create(@"c:\Projects\Tests\test3.txt");
            f2.Dispose();
            ObjectManager.RemoveTextFromFile(@"c:\Projects\Tests\test5.txt");
            ObjectManager.WriteTextToFile(@"c:\Projects\Tests\test6.txt", "some text");
            Directory.Delete(@"c:\Projects\Tests\Test1");
            Directory.CreateDirectory(@"c:\Projects\Tests\Test2");
            Directory.CreateDirectory(@"c:\Projects\Tests\Test3\test.txt");
            Directory.Move(@"c:\Projects\Tests\NewFolder\AnotherFolder\MoveMe", @"c:\Projects\Tests\NewFolder\MoveMe");
            FileStream f3 = File.Create(@"c:\Projects\Tests\RenameMe.txt");
            f3.Dispose();
            File.Delete(@"c:\Projects\Tests\Renamed");
            Directory.CreateDirectory(@"c:\NewFolder");
            Directory.Delete(@"c:\NewFolderino");
        } 
    }
    public class ObjectManagerClassTheoryTest : IClassFixture<TestFixture>
    {
        TestFixture setup;
        public void SetFixture(TestFixture setup)
         {
            this.setup = setup;
         }

        [Theory]
        [InlineData(@"c:\Logs")]
        public void DoesFolderExistTheory_KnownToExist(string folderPath)
        {
            //Assign
            bool folderExists;
            
            //Act
            folderExists = ObjectManager.CheckFolderExists(folderPath);

            //Assert
            Assert.True(folderExists, "This folder does not exist");
        }

        [Theory]
        [InlineDataAttribute(@"c:\Logs\Application.evtx")]
        public void DoesFileExist_KnownToExist(string filePath)
        {
            //Assign
            bool fileExists;

            //Act
            fileExists = ObjectManager.CheckFileExists(filePath);

            //Assert
            Assert.True(fileExists);
        }

        [Theory]
        [InlineData(@"c:\Logs")]
        public void CanLoadListOfFilesInFolder(string folderPath)
        {
            //Assign
            int fileListLength;

            //Act
            var fileList = ObjectManager.ListFilesInDirectory(folderPath);
            fileListLength = fileList.Length;

            //Assert
            Assert.Equal(fileListLength, 84);
        }

        [Theory]
        [InlineDataAttribute(@"c:\EmptyFolder")]
        public void ThrowsExceptionIfFolderEmpty(string folderPath)
        {
            //Assign
            string expectedMessage = "There are no files in this directory";

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => ObjectManager.ListFilesInDirectory(folderPath));

            //Assert
            Assert.Equal(exception.Message, expectedMessage);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests")]
        public void CanGenerateListOfSubfolders(string folderPath)
        {
            //Assign
            int expectedLength = 5;

            //Act
            string[] subfolderList = ObjectManager.ListSubfoldersInDirectory(folderPath);
            int subfolderListLength = subfolderList.Length;

            //Assert
            Assert.Equal(subfolderListLength, expectedLength);
        }

        [Theory]
        [InlineData(@"c:\Logs\Application.evtx")]
        public void CanGetSizeOfFile(string filePath)
        {
            //Assign
            long fileSize;
            string expectedSize = "68KB";

            //Act
            fileSize = ObjectManager.GetSizeOfFile(filePath);
            string answer = Utilities.SelectAppropriateFileSizeFormat(fileSize);

            //Assert
            Assert.Equal(answer, expectedSize);
        }

        [Theory]
        [InlineDataAttribute(@"c:\1170735")]
        public void OutputsErrorIfFileDoesntExist(string filePath)
        {
            //Assign
            string expectedException = "This file does not exist";

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => ObjectManager.GetSizeOfFile(filePath));

            //Assert
            Assert.Equal(exception.Message, expectedException);
        }

        [Theory]
        [InlineData(@"c:\Logs")]
        public void CalculateSizeOfListOfFiles_ExcludingSubfolders(string folderPath)
        {
            //Assign
            long fileListSize;
            string expectedSize = "16.2MB";

            //Act
            fileListSize = ObjectManager.GetSizeOfFileList(folderPath);
            string answer = Utilities.SelectAppropriateFileSizeFormat(fileListSize);

            //Assert
            Assert.Equal(answer, expectedSize);
        }

        [Theory]
        [InlineDataAttribute(@"c:\MadeUpDirectoryLocation")]
        public void ThrowsExceptionIfFolderDoesntExist_GetSizeOfFileList(string folderPath)
        {
            //Assign
            string expectedException = "This folder does not exist";

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => ObjectManager.GetSizeOfFileList(folderPath));

            //Assert
            Assert.Equal(expectedException, exception.Message);
        }

        [Theory]
        [InlineData(@"c:\Vision Australia")]
        public void CalculateSizeOfListOfFiles_IncludingSubfolders(string folderPath)
        {
            //Assign
            long totalSizeOfDirectory;
            string expectedSize = "1.12MB";

            //Act
            totalSizeOfDirectory = ObjectManager.GetSizeOfDirectory(folderPath);
            string answer = Utilities.SelectAppropriateFileSizeFormat(totalSizeOfDirectory);

            //Assert
            Assert.Equal(answer, expectedSize);
        }

        [Theory]
        [InlineDataAttribute(@"c:\FolderThatIsntReal")]
        public void ThrowsExceptionWhenFolderDoesntExist_GetSizeOfDirectory(string folderPath)
        {
            //Assign
            string expectedException = "This folder does not exist";

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => ObjectManager.GetSizeOfDirectory(folderPath));

            //Assert
            Assert.Equal(exception.Message, expectedException);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test1.txt")]
        public void CanCreateNewFile_DoesntAlreadyExist(string filePath)
        {
            //Assign
            bool fileExists;

            //Act
            ObjectManager.CreateNewFile(filePath);
            fileExists = ObjectManager.CheckFileExists(filePath);

            //Assert
            Assert.True(fileExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test2.txt")]
        public void ThrowsExceptionIfTryingToCreateFile_AlreadyExists(string filePath)
        {
            //Assign
            string expectedMessage = "A file already exists at this location, or this is not a valid file path";

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => ObjectManager.CreateNewFile(filePath));

            //Assert
            Assert.Equal(exception.Message, expectedMessage);
        }

        [Theory]
        [InlineDataAttribute("keyboardmashpiuesdv")]
        public void ThrowsExceptionIfTryingToCreateFile_WrongFormat(string filePath)
        {
            //Assign
            string expectedException = "A file already exists at this location, or this is not a valid file path";
            
            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => ObjectManager.CreateNewFile(filePath));

            //Assert
            Assert.Equal(exception.Message, expectedException);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test3.txt")]
        public void CanRemoveFile(string filePath)
        {
            //Assign
            bool fileExists;

            //Act
            ObjectManager.RemoveFile(filePath);
            fileExists = ObjectManager.CheckFileExists(filePath);

            //Assert
            Assert.False(fileExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\MadeUpFileName.txt")]
        public void ThrowsExceptionIfTryingToRemoveFile_DoesntExists(string filePath)
        {
            //Assign
            string expectedMessage = "This file does not exist";

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => ObjectManager.RemoveFile(filePath));

            //Assert
            Assert.Equal(exception.Message, expectedMessage);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\MoveFile.txt", @"c:\Projects\Tests\Test4\MovedFile.txt")]
        public void CanMoveFile(string filePath, string newPath)
        {
            //Assign
            bool fileExists;

            //Act
            ObjectManager.MoveFile(filePath, newPath);
            fileExists = ObjectManager.CheckFileExists(@"c:\Projects\Tests\Test4\MovedFile.txt");

            //Assert
            Assert.True(fileExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\RenameMe.txt", "Renamed")]
        public void CanRenameFile(string oldPath, string newName)
        {
            //Assign
            bool fileExists;

            //Act
            ObjectManager.RenameFile(oldPath, newName);
            fileExists = ObjectManager.CheckFileExists(@"c:\Projects\Tests\Renamed");

            //Assert
            Assert.True(fileExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test4.txt")]
        public void CanReadTextFromFile(string filePath)
        {
            //Assign
            string text;
            string expectedResult = "testing 1, 2";

            //Act
            text = ObjectManager.ReadTextFromFile(filePath);

            //Assert
            Assert.Equal(text, expectedResult);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test4.txt", "testing 1, 2")]
        public void CanSearchForTextInFile_TextPresent(string filePath, string searchQuery)
        {
            //Assign
            bool answer;

            //Act
            answer = ObjectManager.SearchForTextInFile(filePath, searchQuery);

            //Assert
            Assert.True(answer);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test4.txt", "some words")]
        public void CanSearchForTextInFile_TextNotPresent(string filePath, string searchQuery)
        {
            //Assign
            bool answer;

            //Act
            answer = ObjectManager.SearchForTextInFile(filePath, searchQuery);

            //Assert
            Assert.False(answer);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test4.txt")]
        public void CanCountLinesInTextFile(string filePath)
        {
            //Assign
            int answer;
            int expectedResult = 1;

            //Act
            answer = ObjectManager.CountLinesInFile(filePath);

            //Assert
            Assert.Equal(answer, expectedResult);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test5.txt", "some text")]
        public void CanWriteToFile(string filePath, string text)
        {
            //Assign
            string finalText;
            string expectedResult = "some text";

            //Act
            ObjectManager.WriteTextToFile(filePath, text);
            finalText = ObjectManager.ReadTextFromFile(filePath);

            //Assert
            Assert.Equal(finalText, expectedResult);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test6.txt")]
        public void CanRemoveTextFromFile(string filePath)
        {
            //Assign
            string text = "some text";
            string expectedResult = "";

            //Act
            ObjectManager.RemoveTextFromFile(filePath);
            text = ObjectManager.ReadTextFromFile(filePath);

            //Assert
            Assert.Equal(text, expectedResult);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test7.txt")]
        public void CanGetTimeStampForLastAccess(string filePath)
        {
            //Access
            string answer;
            string expectedResult = "2017/01/25 09:32:30.52";

            //Act
            answer = ObjectManager.GetTimeStampForLastAccess(filePath);

            //Assert
            Assert.Equal(answer, expectedResult);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\Test1")]
        public void CanCreateNewFolder(string newFolderPath)
        {
            //Assign
            bool folderExists;

            //Act
            ObjectManager.CreateNewFolder(newFolderPath);
            folderExists = ObjectManager.CheckFolderExists(newFolderPath);

            //Assert
            Assert.True(folderExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\Test2", true)]
        public void CanRemoveFolder_FolderEmpty(string folderPath, bool recursive)
        {
            //Assign
            bool folderExists;

            //Act
            ObjectManager.RemoveFolder(folderPath, recursive);
            folderExists = ObjectManager.CheckFolderExists(folderPath);

            //Assert
            Assert.False(folderExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\Test3", @"c:\Projects\Tests\Test3\test.txt", true)]
        public void CanRemoveFolder_FolderNotEmpty(string folderPath, string filePath, bool recursive)
        {
            //Assign
            bool folderExists;

            //Act
            ObjectManager.RemoveFolder(folderPath, recursive);
            folderExists = ObjectManager.CheckFolderExists(folderPath);

            //Assert
            Assert.False(folderExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\NewFolder\MoveMe", @"c:\Projects\Tests\NewFolder\AnotherFolder\MoveMe")]
        public void CanMoveFolder(string oldPath, string newPath)
        {
            //Assign

            //Act
            ObjectManager.MoveFolder(oldPath, newPath);
            bool result = ObjectManager.CheckFolderExists(newPath);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\fakefolder", @"c:\Podjiaoifjwhateverdoesntmattre")]
        public void ThrowsExceptionTryingToMoveFolder_DoesntExist(string oldPath, string newPath)
        {
            //Assign
            string expectedException = "This folder does not exist";

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => ObjectManager.MoveFolder(oldPath, newPath));

            //Assert
            Assert.Equal(exception.Message, expectedException);
        }

        [Theory]
        [InlineDataAttribute(@"c:\NewFolder", "NewFolderino")]
        public void CanRenameFolder(string oldPath, string newName)
        {
            //Assign
            bool result;

            //Act
            ObjectManager.RenameFolder(oldPath, newName);
            result = ObjectManager.CheckFolderExists(@"c:\NewFolderino");

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\doesntreallymatter", "whatevevever")]
        public void ThrowsExceptionRenamingFile_DoesntExist(string oldPath, string newName)
        {
            //Assign
            string exceptionMessage = "This folder does not exist";

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => ObjectManager.RenameFolder(oldPath, newName));            

            //Assert
            Assert.Equal(exception.Message, exceptionMessage);
        }

        // [Theory]
        // [InlineDataAttribute(@"c:\Projects\Tests\IndexTests")]
        // public void CanCreateIndexFileWithPopulatedDirectory(string folderPath)
        // {
        //     //Assign
        //     string indexPath = folderPath + "\\Index.txt";
        //     Options.input = "c:\\Projects\\Tests\\IndexTests";
        //     int expectedResult = 17;

        //     //Act
        //     ObjectManager.CreateIndexFile(folderPath);
        //     int lineCount = File.ReadLines(indexPath).Count();

        //     //Assert
        //     Assert.Equal(lineCount, expectedResult);
        // }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\MadeUpFolder")]
        public void ThrowsExceptionIfTryingToCreateIndexFile_FolderDoesntExists(string folderPath)
        {
            //Assign
            string expectedException = "This folder does not exist";

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => ObjectManager.CreateIndexFile(folderPath));

            //Assign
            Assert.Equal(exception.Message, expectedException);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\index.txt")]
        public void CanRemovePathFromFileName(string filePath)
        {
            //Assign
            string expectedResult = "index.txt";

            //Act
            string fileName = ObjectManager.RemovePathFromName(filePath);

            //Assert
            Assert.Equal(fileName, expectedResult);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\index.txt")]
        public void CanTruncateFile(string filePath)
        {
            //Assign
            string expectedResult = "0KB";

            //Act
            ObjectManager.TruncateFile(filePath);
            string fileSize = filePath.FileSize();

            //Assert
            Assert.Equal(expectedResult, fileSize);
        }
    }
}
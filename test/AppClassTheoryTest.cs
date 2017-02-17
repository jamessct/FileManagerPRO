using System;
using System.IO;
using System.Linq;
using Xunit;
using ConsoleApplication;

namespace MyApp
{
    public class TestFixture 
    {
        public TestFixture()
        {
            var myInstanceOfApphelper = new AppHelper();
            File.Delete(@"c:\Projects\Tests\test1.txt");
            File.Create(@"c:\Projects\Tests\test2.txt");
            FileStream f1 = File.Create(@"c:\Projects\Tests\MoveFile.txt");
            f1.Dispose();
            File.Delete(@"c:\Projects\Tests\Test4\MovedFile.txt");
            FileStream f2 = File.Create(@"c:\Projects\Tests\test3.txt");
            f2.Dispose();
            myInstanceOfApphelper.RemoveTextFromFile(@"c:\Projects\Tests\test5.txt");
            myInstanceOfApphelper.WriteTextToFile(@"c:\Projects\Tests\test6.txt", "some text");
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
    public class AppClassTheoryTest : IClassFixture<TestFixture>
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
            var myInstanceOfApphelper = new AppHelper();

            //Act
            folderExists = myInstanceOfApphelper.CheckFolderExists(folderPath);

            //Assert
            Assert.True(folderExists, "This folder does not exist");
        }

        [Theory]
        [InlineDataAttribute(@"c:\Logs\Application.evtx")]
        public void DoesFileExist_KnownToExist(string filePath)
        {
            //Assign
            bool fileExists;
            var myInstanceOfApphelper = new AppHelper();

            //Act
            fileExists = myInstanceOfApphelper.CheckFileExists(filePath);

            //Assert
            Assert.True(fileExists);
        }

        [Theory]
        [InlineData(@"c:\Logs")]
        public void CanLoadListOfFilesInFolder(string folderPath)
        {
            //Assign
            int fileListLength;
            var myInstanceOfApphelper = new AppHelper();

            //Act
            var fileList = myInstanceOfApphelper.ListFilesInDirectory(folderPath);
            fileListLength = fileList.Length;

            //Assert
            Assert.Equal(fileListLength, 84);
        }

        [Theory]
        [InlineDataAttribute(@"c:\EmptyFolder")]
        public void ThrowsExceptionIfFolderEmpty(string folderPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => myInstanceOfApphelper.ListFilesInDirectory(folderPath));

            //Assert
            Assert.Equal(exception.Message, "There are no files in this directory");
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests")]
        public void CanGenerateListOfSubfolders(string folderPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            int expectedLength = 5;

            //Act
            string[] subfolderList = myInstanceOfApphelper.ListSubfoldersInDirectory(folderPath);
            int subfolderListLength = subfolderList.Length;

            //Assert
            Assert.Equal(subfolderListLength, expectedLength);
        }

        [Theory]
        [InlineData(@"c:\Logs\Application.evtx")]
        public void CanGetSizeOfFile(string filePath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            long fileSize;

            //Act
            fileSize = myInstanceOfApphelper.GetSizeOfFile(filePath);
            string answer = Utilities.SelectAppropriateFileSizeFormat(fileSize);

            //Assert
            Assert.Equal(answer, "68KB");
        }

        [Theory]
        [InlineDataAttribute(@"c:\1170735")]
        public void OutputsErrorIfFileDoesntExist(string filePath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => myInstanceOfApphelper.GetSizeOfFile(filePath));

            //Assert
            Assert.Equal(exception.Message, "This file does not exist");
        }

        [Theory]
        [InlineData(@"c:\Logs")]
        public void CalculateSizeOfListOfFiles_ExcludingSubfolders(string folderPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            long fileListSize;

            //Act
            fileListSize = myInstanceOfApphelper.GetSizeOfFileList(folderPath);
            string answer = Utilities.SelectAppropriateFileSizeFormat(fileListSize);

            //Assert
            Assert.Equal(answer, "16.2MB");
        }

        [Theory]
        [InlineDataAttribute(@"c:\MadeUpDirectoryLocation")]
        public void ThrowsExceptionIfFolderDoesntExist_GetSizeOfFileList(string folderPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => myInstanceOfApphelper.GetSizeOfFileList(folderPath));

            //Assert
            Assert.Equal("This folder does not exist", exception.Message);
        }

        [Theory]
        [InlineData(@"c:\Vision Australia")]
        public void CalculateSizeOfListOfFiles_IncludingSubfolders(string folderPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            long totalSizeOfDirectory;

            //Act
            totalSizeOfDirectory = myInstanceOfApphelper.GetSizeOfDirectory(folderPath);
            string answer = Utilities.SelectAppropriateFileSizeFormat(totalSizeOfDirectory);

            //Assert
            Assert.Equal(answer, "1.12MB");
        }

        [Theory]
        [InlineDataAttribute(@"c:\FolderThatIsntReal")]
        public void ThrowsExceptionWhenFolderDoesntExist_GetSizeOfDirectory(string folderPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => myInstanceOfApphelper.GetSizeOfDirectory(folderPath));

            //Assert
            Assert.Equal(exception.Message, "This folder does not exist");
        }

        // load a list of files in the folder [DONE]

        // for a single file get it file size [DONE]

        // caculate the size of a single list of files ignoring subfolders [DONE]

        // calculate the size of a subfolder including [DONE]

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test1.txt")]
        public void CanCreateNewFile_DoesntAlreadyExist(string filePath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            bool fileExists;

            //Act
            myInstanceOfApphelper.CreateNewFile(filePath);
            fileExists = myInstanceOfApphelper.CheckFileExists(filePath);

            //Assert
            Assert.True(fileExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test2.txt")]
        public void ThrowsExceptionIfTryingToCreateFile_AlreadyExists(string filePath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => myInstanceOfApphelper.CreateNewFile(filePath));

            //Assert
            Assert.Equal(exception.Message, "A file already exists at this location, or this is not a valid file path");
        }

        [Theory]
        [InlineDataAttribute("keyboardmashpiuesdv")]
        public void ThrowsExceptionIfTryingToCreateFile_WrongFormat(string filePath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            
            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => myInstanceOfApphelper.CreateNewFile(filePath));

            //Assert
            Assert.Equal(exception.Message, "A file already exists at this location, or this is not a valid file path");
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test3.txt")]
        public void CanRemoveFile(string filePath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            bool fileExists;

            //Act
            myInstanceOfApphelper.RemoveFile(filePath);
            fileExists = myInstanceOfApphelper.CheckFileExists(filePath);

            //Assert
            Assert.Equal(false, fileExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\MadeUpFileName.txt")]
        public void ThrowsExceptionIfTryingToRemoveFile_DoesntExists(string filePath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();

           //Act
            Exception exception = Assert.Throws<ArgumentException>(() => myInstanceOfApphelper.RemoveFile(filePath));

            //Assert
            Assert.Equal(exception.Message, "This file does not exist");
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\MoveFile.txt", @"c:\Projects\Tests\Test4\MovedFile.txt")]
        public void CanMoveFile(string filePath, string newPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            bool fileExists;

            //Act
            myInstanceOfApphelper.MoveFile(filePath, newPath);
            fileExists = myInstanceOfApphelper.CheckFileExists(@"c:\Projects\Tests\Test4\MovedFile.txt");

            //Assert
            Assert.Equal(fileExists, true);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\RenameMe.txt", "Renamed")]
        public void CanRenameFile(string oldPath, string newName)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            bool fileExists;

            //Act
            myInstanceOfApphelper.RenameFile(oldPath, newName);
            fileExists = myInstanceOfApphelper.CheckFileExists(@"c:\Projects\Tests\Renamed");

            //Assert
            Assert.True(fileExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test4.txt")]
        public void CanReadFromFile(string filePath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            string text;

            //Act
            text = myInstanceOfApphelper.ReadTextFromFile(filePath);

            //Assert
            Assert.Equal(text, "testing 1, 2");
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test4.txt", "testing 1, 2")]
        public void CanSearchForTextInFile_TextPresent(string filePath, string searchQuery)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            bool answer;

            //Act
            answer = myInstanceOfApphelper.SearchForTextInFile(filePath, searchQuery);

            //Assert
            Assert.Equal(answer, true);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test4.txt", "some words")]
        public void CanSearchForTextInFile_TextNotPresent(string filePath, string searchQuery)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            bool answer;

            //Act
            answer = myInstanceOfApphelper.SearchForTextInFile(filePath, searchQuery);

            //Assert
            Assert.Equal(answer, false);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test4.txt")]
        public void CanCountLinesInTextFile(string filePath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            int answer;

            //Act
            answer = myInstanceOfApphelper.CountLinesInFile(filePath);

            //Assert
            Assert.Equal(answer, 1);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test5.txt", "some text")]
        public void CanWriteToFile(string filePath, string text)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            string finalText;

            //Act
            myInstanceOfApphelper.WriteTextToFile(filePath, text);
            finalText = myInstanceOfApphelper.ReadTextFromFile(filePath);

            //Assert
            Assert.Equal(finalText, "some text");
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test6.txt")]
        public void CanRemoveTextFromFile(string filePath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            string text = "some text";

            //Act
            myInstanceOfApphelper.RemoveTextFromFile(filePath);
            text = myInstanceOfApphelper.ReadTextFromFile(filePath);

            //Assert
            Assert.Equal(text, "");
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\test7.txt")]
        public void CanGetTimeStampForLastAccess(string filePath)
        {
            //Access
            var myInstanceOfApphelper = new AppHelper();
            string answer;

            //Act
            answer = myInstanceOfApphelper.GetTimeStampForLastAccess(filePath);

            //Assert
            Assert.Equal(answer, "2017/01/25 09:32:30.52");
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\Test1")]
        public void CanCreateNewFolder(string newFolderPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            bool folderExists;

            //Act
            myInstanceOfApphelper.CreateNewFolder(newFolderPath);
            folderExists = myInstanceOfApphelper.CheckFolderExists(newFolderPath);

            //Assert
            Assert.True(folderExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\Test2", true)]
        public void CanRemoveFolder_FolderEmpty(string folderPath, bool recursive)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            bool folderExists;

            //Act
            myInstanceOfApphelper.RemoveFolder(folderPath, recursive);
            folderExists = myInstanceOfApphelper.CheckFolderExists(folderPath);

            //Assert
            Assert.False(folderExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\Test3", @"c:\Projects\Tests\Test3\test.txt", true)]
        public void CanRemoveFolder_FolderNotEmpty(string folderPath, string filePath, bool recursive)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            bool folderExists;

            //Act
            myInstanceOfApphelper.RemoveFolder(folderPath, recursive);
            folderExists = myInstanceOfApphelper.CheckFolderExists(folderPath);

            //Assert
            Assert.False(folderExists);
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\NewFolder\MoveMe", @"c:\Projects\Tests\NewFolder\AnotherFolder\MoveMe")]
        public void CanMoveFolder(string oldPath, string newPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();

            //Act
            myInstanceOfApphelper.MoveFolder(oldPath, newPath);
            bool result = myInstanceOfApphelper.CheckFolderExists(newPath);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\fakefolder", @"c:\Podjiaoifjwhateverdoesntmattre")]
        public void ThrowsExceptionTryingToMoveFolder_DoesntExist(string oldPath, string newPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => myInstanceOfApphelper.MoveFolder(oldPath, newPath));

            //Assert
            Assert.Equal(exception.Message, "This folder does not exist");
        }

        [Theory]
        [InlineDataAttribute(@"c:\NewFolder", "NewFolderino")]
        public void CanRenameFolder(string oldPath, string newName)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            bool result;

            //Act
            myInstanceOfApphelper.RenameFolder(oldPath, newName);
            result = myInstanceOfApphelper.CheckFolderExists(@"c:\NewFolderino");

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineDataAttribute(@"c:\doesntreallymatter", "whatevevever")]
        public void ThrowsExceptionRenamingFile_DoesntExist(string oldPath, string newName)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => myInstanceOfApphelper.RenameFolder(oldPath, newName));            

            //Assert
            Assert.Equal(exception.Message, "This folder does not exist");
        }

        [Theory]
        [InlineDataAttribute(@"c:\Projects\Tests\IndexTests")]
        public void CanCreateIndexFileWithPopulatedDirectory(string folderPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();
            string indexPath = folderPath + "\\Index.txt";
            Options.input = "c:\\Projects\\Tests\\IndexTests";

            //Act
            myInstanceOfApphelper.CreateIndexFile(folderPath);
            int lineCount = File.ReadLines(indexPath).Count();

            //Assert
            Assert.Equal(lineCount, 17);
        }

        [Theory]
        [InlineDataAttribute(@"c\Projects\Tests\MadeUpFolder")]
        public void ThrowsExceptionIfTryingToCreateIndexFile_FolderDoesntExists(string folderPath)
        {
            //Assign
            var myInstanceOfApphelper = new AppHelper();

            //Act
            Exception exception = Assert.Throws<ArgumentException>(() => myInstanceOfApphelper.CreateIndexFile(folderPath));

            //Assign
            Assert.Equal(exception.Message, "This folder does not exist");
        }
    }
}
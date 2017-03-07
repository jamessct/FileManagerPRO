// using System;
// using System.IO;
// using System.Linq;
// using Xunit;
// using ConsoleApplication;

// namespace MyApp
// {
//     public class TestFixture 
//     {
//         public TestFixture()
//         {
//             ObjectManager app = new ObjectManager();
//             File.Delete(@"c:\Projects\Tests\test1.txt");
//             File.Create(@"c:\Projects\Tests\test2.txt");
//             FileStream f1 = File.Create(@"c:\Projects\Tests\MoveFile.txt");
//             f1.Dispose();
//             File.Delete(@"c:\Projects\Tests\Test4\MovedFile.txt");
//             FileStream f2 = File.Create(@"c:\Projects\Tests\test3.txt");
//             f2.Dispose();
//             app.RemoveTextFromFile(@"c:\Projects\Tests\test5.txt");
//             app.WriteTextToFile(@"c:\Projects\Tests\test6.txt", "some text");
//             Directory.Delete(@"c:\Projects\Tests\Test1");
//             Directory.CreateDirectory(@"c:\Projects\Tests\Test2");
//             Directory.CreateDirectory(@"c:\Projects\Tests\Test3\test.txt");
//             Directory.Move(@"c:\Projects\Tests\NewFolder\AnotherFolder\MoveMe", @"c:\Projects\Tests\NewFolder\MoveMe");
//             FileStream f3 = File.Create(@"c:\Projects\Tests\RenameMe.txt");
//             f3.Dispose();
//             File.Delete(@"c:\Projects\Tests\Renamed");
//             Directory.CreateDirectory(@"c:\NewFolder");
//             Directory.Delete(@"c:\NewFolderino");
//         } 
//     }
//     public class AppClassTheoryTest : IClassFixture<TestFixture>
//     {
//         TestFixture setup;
//         public void SetFixture(TestFixture setup)
//          {
//             this.setup = setup;
//          }

//         [Theory]
//         [InlineData(@"c:\Logs")]
//         public void DoesFolderExistTheory_KnownToExist(string folderPath)
//         {
//             //Assign
//             bool folderExists;
//             ObjectManager app = new ObjectManager();

//             //Act
//             folderExists = app.CheckFolderExists(folderPath);

//             //Assert
//             Assert.True(folderExists, "This folder does not exist");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Logs\Application.evtx")]
//         public void DoesFileExist_KnownToExist(string filePath)
//         {
//             //Assign
//             bool fileExists;
//             ObjectManager app = new ObjectManager();

//             //Act
//             fileExists = app.CheckFileExists(filePath);

//             //Assert
//             Assert.True(fileExists);
//         }

//         [Theory]
//         [InlineData(@"c:\Logs")]
//         public void CanLoadListOfFilesInFolder(string folderPath)
//         {
//             //Assign
//             int fileListLength;
//             ObjectManager app = new ObjectManager();

//             //Act
//             var fileList = app.ListFilesInDirectory(folderPath);
//             fileListLength = fileList.Length;

//             //Assert
//             Assert.Equal(fileListLength, 84);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\EmptyFolder")]
//         public void ThrowsExceptionIfFolderEmpty(string folderPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();

//             //Act
//             Exception exception = Assert.Throws<ArgumentException>(() => app.ListFilesInDirectory(folderPath));

//             //Assert
//             Assert.Equal(exception.Message, "There are no files in this directory");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests")]
//         public void CanGenerateListOfSubfolders(string folderPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             int expectedLength = 5;

//             //Act
//             string[] subfolderList = app.ListSubfoldersInDirectory(folderPath);
//             int subfolderListLength = subfolderList.Length;

//             //Assert
//             Assert.Equal(subfolderListLength, expectedLength);
//         }

//         [Theory]
//         [InlineData(@"c:\Logs\Application.evtx")]
//         public void CanGetSizeOfFile(string filePath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             long fileSize;

//             //Act
//             fileSize = app.GetSizeOfFile(filePath);
//             string answer = Utilities.SelectAppropriateFileSizeFormat(fileSize);

//             //Assert
//             Assert.Equal(answer, "68KB");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\1170735")]
//         public void OutputsErrorIfFileDoesntExist(string filePath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();

//             //Act
//             Exception exception = Assert.Throws<ArgumentException>(() => app.GetSizeOfFile(filePath));

//             //Assert
//             Assert.Equal(exception.Message, "This file does not exist");
//         }

//         [Theory]
//         [InlineData(@"c:\Logs")]
//         public void CalculateSizeOfListOfFiles_ExcludingSubfolders(string folderPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             long fileListSize;

//             //Act
//             fileListSize = app.GetSizeOfFileList(folderPath);
//             string answer = Utilities.SelectAppropriateFileSizeFormat(fileListSize);

//             //Assert
//             Assert.Equal(answer, "16.2MB");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\MadeUpDirectoryLocation")]
//         public void ThrowsExceptionIfFolderDoesntExist_GetSizeOfFileList(string folderPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();

//             //Act
//             Exception exception = Assert.Throws<ArgumentException>(() => app.GetSizeOfFileList(folderPath));

//             //Assert
//             Assert.Equal("This folder does not exist", exception.Message);
//         }

//         [Theory]
//         [InlineData(@"c:\Vision Australia")]
//         public void CalculateSizeOfListOfFiles_IncludingSubfolders(string folderPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             long totalSizeOfDirectory;

//             //Act
//             totalSizeOfDirectory = app.GetSizeOfDirectory(folderPath);
//             string answer = Utilities.SelectAppropriateFileSizeFormat(totalSizeOfDirectory);

//             //Assert
//             Assert.Equal(answer, "1.12MB");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\FolderThatIsntReal")]
//         public void ThrowsExceptionWhenFolderDoesntExist_GetSizeOfDirectory(string folderPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();

//             //Act
//             Exception exception = Assert.Throws<ArgumentException>(() => app.GetSizeOfDirectory(folderPath));

//             //Assert
//             Assert.Equal(exception.Message, "This folder does not exist");
//         }

//         // load a list of files in the folder [DONE]

//         // for a single file get it file size [DONE]

//         // caculate the size of a single list of files ignoring subfolders [DONE]

//         // calculate the size of a subfolder including [DONE]

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\test1.txt")]
//         public void CanCreateNewFile_DoesntAlreadyExist(string filePath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             bool fileExists;

//             //Act
//             app.CreateNewFile(filePath);
//             fileExists = app.CheckFileExists(filePath);

//             //Assert
//             Assert.True(fileExists);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\test2.txt")]
//         public void ThrowsExceptionIfTryingToCreateFile_AlreadyExists(string filePath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();

//             //Act
//             Exception exception = Assert.Throws<ArgumentException>(() => app.CreateNewFile(filePath));

//             //Assert
//             Assert.Equal(exception.Message, "A file already exists at this location, or this is not a valid file path");
//         }

//         [Theory]
//         [InlineDataAttribute("keyboardmashpiuesdv")]
//         public void ThrowsExceptionIfTryingToCreateFile_WrongFormat(string filePath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
            
//             //Act
//             Exception exception = Assert.Throws<ArgumentException>(() => app.CreateNewFile(filePath));

//             //Assert
//             Assert.Equal(exception.Message, "A file already exists at this location, or this is not a valid file path");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\test3.txt")]
//         public void CanRemoveFile(string filePath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             bool fileExists;

//             //Act
//             app.RemoveFile(filePath);
//             fileExists = app.CheckFileExists(filePath);

//             //Assert
//             Assert.Equal(false, fileExists);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\MadeUpFileName.txt")]
//         public void ThrowsExceptionIfTryingToRemoveFile_DoesntExists(string filePath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();

//            //Act
//             Exception exception = Assert.Throws<ArgumentException>(() => app.RemoveFile(filePath));

//             //Assert
//             Assert.Equal(exception.Message, "This file does not exist");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\MoveFile.txt", @"c:\Projects\Tests\Test4\MovedFile.txt")]
//         public void CanMoveFile(string filePath, string newPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             bool fileExists;

//             //Act
//             app.MoveFile(filePath, newPath);
//             fileExists = app.CheckFileExists(@"c:\Projects\Tests\Test4\MovedFile.txt");

//             //Assert
//             Assert.Equal(fileExists, true);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\RenameMe.txt", "Renamed")]
//         public void CanRenameFile(string oldPath, string newName)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             bool fileExists;

//             //Act
//             app.RenameFile(oldPath, newName);
//             fileExists = app.CheckFileExists(@"c:\Projects\Tests\Renamed");

//             //Assert
//             Assert.True(fileExists);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\test4.txt")]
//         public void CanReadFromFile(string filePath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             string text;

//             //Act
//             text = app.ReadTextFromFile(filePath);

//             //Assert
//             Assert.Equal(text, "testing 1, 2");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\test4.txt", "testing 1, 2")]
//         public void CanSearchForTextInFile_TextPresent(string filePath, string searchQuery)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             bool answer;

//             //Act
//             answer = app.SearchForTextInFile(filePath, searchQuery);

//             //Assert
//             Assert.Equal(answer, true);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\test4.txt", "some words")]
//         public void CanSearchForTextInFile_TextNotPresent(string filePath, string searchQuery)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             bool answer;

//             //Act
//             answer = app.SearchForTextInFile(filePath, searchQuery);

//             //Assert
//             Assert.Equal(answer, false);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\test4.txt")]
//         public void CanCountLinesInTextFile(string filePath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             int answer;

//             //Act
//             answer = app.CountLinesInFile(filePath);

//             //Assert
//             Assert.Equal(answer, 1);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\test5.txt", "some text")]
//         public void CanWriteToFile(string filePath, string text)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             string finalText;

//             //Act
//             app.WriteTextToFile(filePath, text);
//             finalText = app.ReadTextFromFile(filePath);

//             //Assert
//             Assert.Equal(finalText, "some text");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\test6.txt")]
//         public void CanRemoveTextFromFile(string filePath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             string text = "some text";

//             //Act
//             app.RemoveTextFromFile(filePath);
//             text = app.ReadTextFromFile(filePath);

//             //Assert
//             Assert.Equal(text, "");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\test7.txt")]
//         public void CanGetTimeStampForLastAccess(string filePath)
//         {
//             //Access
//             ObjectManager app = new ObjectManager();
//             string answer;

//             //Act
//             answer = app.GetTimeStampForLastAccess(filePath);

//             //Assert
//             Assert.Equal(answer, "2017/01/25 09:32:30.52");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\Test1")]
//         public void CanCreateNewFolder(string newFolderPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             bool folderExists;

//             //Act
//             app.CreateNewFolder(newFolderPath);
//             folderExists = app.CheckFolderExists(newFolderPath);

//             //Assert
//             Assert.True(folderExists);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\Test2", true)]
//         public void CanRemoveFolder_FolderEmpty(string folderPath, bool recursive)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             bool folderExists;

//             //Act
//             app.RemoveFolder(folderPath, recursive);
//             folderExists = app.CheckFolderExists(folderPath);

//             //Assert
//             Assert.False(folderExists);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\Test3", @"c:\Projects\Tests\Test3\test.txt", true)]
//         public void CanRemoveFolder_FolderNotEmpty(string folderPath, string filePath, bool recursive)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             bool folderExists;

//             //Act
//             app.RemoveFolder(folderPath, recursive);
//             folderExists = app.CheckFolderExists(folderPath);

//             //Assert
//             Assert.False(folderExists);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\NewFolder\MoveMe", @"c:\Projects\Tests\NewFolder\AnotherFolder\MoveMe")]
//         public void CanMoveFolder(string oldPath, string newPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();

//             //Act
//             app.MoveFolder(oldPath, newPath);
//             bool result = app.CheckFolderExists(newPath);

//             //Assert
//             Assert.True(result);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\fakefolder", @"c:\Podjiaoifjwhateverdoesntmattre")]
//         public void ThrowsExceptionTryingToMoveFolder_DoesntExist(string oldPath, string newPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();

//             //Act
//             Exception exception = Assert.Throws<ArgumentException>(() => app.MoveFolder(oldPath, newPath));

//             //Assert
//             Assert.Equal(exception.Message, "This folder does not exist");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\NewFolder", "NewFolderino")]
//         public void CanRenameFolder(string oldPath, string newName)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             bool result;

//             //Act
//             app.RenameFolder(oldPath, newName);
//             result = ObjectManager.CheckFolderExists(@"c:\NewFolderino");

//             //Assert
//             Assert.True(result);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\doesntreallymatter", "whatevevever")]
//         public void ThrowsExceptionRenamingFile_DoesntExist(string oldPath, string newName)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();

//             //Act
//             Exception exception = Assert.Throws<ArgumentException>(() => app.RenameFolder(oldPath, newName));            

//             //Assert
//             Assert.Equal(exception.Message, "This folder does not exist");
//         }

//         [Theory]
//         [InlineDataAttribute(@"c:\Projects\Tests\IndexTests")]
//         public void CanCreateIndexFileWithPopulatedDirectory(string folderPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();
//             string indexPath = folderPath + "\\Index.txt";
//             Options.input = "c:\\Projects\\Tests\\IndexTests";

//             //Act
//             app.CreateIndexFile(folderPath);
//             int lineCount = File.ReadLines(indexPath).Count();

//             //Assert
//             Assert.Equal(lineCount, 17);
//         }

//         [Theory]
//         [InlineDataAttribute(@"c\Projects\Tests\MadeUpFolder")]
//         public void ThrowsExceptionIfTryingToCreateIndexFile_FolderDoesntExists(string folderPath)
//         {
//             //Assign
//             ObjectManager app = new ObjectManager();

//             //Act
//             Exception exception = Assert.Throws<ArgumentException>(() => app.CreateIndexFile(folderPath));

//             //Assign
//             Assert.Equal(exception.Message, "This folder does not exist");
//         }
//     }
// }
using Xunit;
using ConsoleApplication;

namespace MyApp
{
    public class TableMakerFactTest
    {
        [Fact]
        public void CanCreateLine()
        {
            //Assign
            TableMaker table = new TableMaker();
            string expected = new string('-', 110);

            //Act
            string printLine = table.PrintLine();

            //Assert
            Assert.Equal(printLine, expected);
        }
    }
}
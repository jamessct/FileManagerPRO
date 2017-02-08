using Xunit;
using Xunit.Abstractions;
using ConsoleApplication;

namespace MyApp
{
    public class TableClassFactTest
    {
        private readonly ITestOutputHelper output;

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
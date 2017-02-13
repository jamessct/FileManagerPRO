using Xunit;
using  ConsoleApplication;

namespace MyApp
{
    public class TableMakerTheoryTest
    {
        [Theory]
        [InlineDataAttribute("testing", "1", "2")]
        public void CanCreateRow(string test, string test1, string test2)
        {
            //Assign
            TableMaker table = new TableMaker();
            string[] row = {test, test1, test2};
            string expected = "|              testing              |                 1                 |                 2                 |";

            //Act
            string result = table.PrintRow(row);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
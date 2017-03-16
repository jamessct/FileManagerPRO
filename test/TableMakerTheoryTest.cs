using Xunit;
using Xunit.Abstractions;
using  ConsoleApplication;

namespace MyApp
{
    public class TableMakerTheoryTest
    {
        private readonly ITestOutputHelper output;

        public TableMakerTheoryTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Theory]
        [InlineDataAttribute(0, new string[] {"testing", "1", "2"})]
        public void CanCreateRow(int decoy, string[] row)
        {
            //Assign
            TableMaker table = new TableMaker();
            string expected = "|              testing              |                 1                 |                 2                 |";

            //Act
            string result = table.PrintRow(row);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
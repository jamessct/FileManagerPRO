using System;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
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

        //Would like a test for TableMaker.PrintTableToConsole()
    }
}
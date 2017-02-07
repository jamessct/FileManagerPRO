using Xunit;
using Xunit.Abstractions;
using ConsoleApplication;

namespace MyApp
{
    public class TableClassFactTest
    {
        private readonly ITestOutputHelper output;

        public TableClassFactTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void CanCreateLine()
        {
            //Assign
            var table = new TableMaker();

            //Act
            

            //Assert
            Assert.Equal(Expected, ActualResult);
        }
    }
}
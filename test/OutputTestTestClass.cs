using Xunit;
using Xunit.Abstractions;
using ConsoleApplication;

namespace MyApp
{
    public class OutputTestClass
    {
        private readonly ITestOutputHelper output;

        public OutputTestClass(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void MyTest()
        {
            var temp = "some misc output";
            output.WriteLine("this is output from {0}", temp);
        }

        [Theory]
        [InlineDataAttribute(0, new string[] {"test", "test2", "test3"})]
        public void CanTestForPresenseOfOutput(int no, string[] t2)
        {
            TableMaker table = new TableMaker();
            output.WriteLine(table.CanPrintTableToConsole(t2));
        }
    }
}

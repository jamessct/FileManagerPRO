using Xunit;
using Xunit.Abstractions;

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
    }
}

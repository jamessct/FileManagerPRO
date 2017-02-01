using Xunit;

namespace ConsoleApplicationTests
{
    public class MyFirstFactTest
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        // [Fact]
        // public void FailingTest()
        // {
        //     //Assign
        //     var expected = 5;

        //     //Act
        //     var actual = Add(2,2);

        //     //Assert
        //     Assert.Equal(expected, actual);
        // }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}

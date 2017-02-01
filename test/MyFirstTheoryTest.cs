using Xunit;

namespace MyApp
{
    public class MyFirstTheoryTest
    {
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        //[InlineData(6)] //this would be a failing value
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}
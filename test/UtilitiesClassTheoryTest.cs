using Xunit;

namespace ConsoleApplication
{
    public class UtilitiesClassTheoryTest
    {
        [Theory]
        [InlineDataAttribute(42433)]
        public void ConvertsFileSizeUnder1048576BytesToKB(long bytes)
        {
            //Assign
            string expected = "41.44KB";

            //Act
            string answer = Utilities.SelectAppropriateFileSizeFormat(bytes);

            //Assert
            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineDataAttribute(1048577)]
        public void ConvertsFileSizeOver1048576ToMB(long bytes)
        {
            //Assign
            string expected = "1MB";

            //Act
            string answer = Utilities.SelectAppropriateFileSizeFormat(bytes);

            //Assert
            Assert.Equal(expected, answer);
        } 

        [Theory]
        [InlineDataAttribute(1073741825)]
        public void ConvertsFileSizeOver1073741824toGB(long bytes)
        {
            //Assign
            string expected = "1GB";

            //Act
            string answer = Utilities.SelectAppropriateFileSizeFormat(bytes);

            //Assert
            Assert.Equal(expected, answer);
        }
    }
}
using System;
using Xunit;

namespace Diamond.Tests
{

    public class DiamondTest
    {
        private Diamond diamond = new Diamond();

        [Fact]
        public void Write_A_Diamond()
        {
            //Arrange
            char letter = 'A';

            //Act
            string result = diamond.Print(letter);

            //Assert
            Assert.Equal("A", result);
        }

        [Fact]
        public void Write_B_Diamond()
        {
            //Arrange
            char letter = 'B';

            //Act
            string result = diamond.Print(letter);

            //Assert
            Assert.StartsWith($"A{Environment.NewLine}B", result);
        }
    }

}

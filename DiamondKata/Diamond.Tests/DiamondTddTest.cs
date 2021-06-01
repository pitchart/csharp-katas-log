using System;
using Xunit;

namespace Diamond.Tests
{
    public class DiamondTddTest
    {
        private DiamondTddVersion _diamond = new DiamondTddVersion();

        [Fact]
        public void ShouldBeEmpty_WhenInputISNotLetter()
        {
            var print = _diamond.Print('*');

            Assert.Equal(string.Empty, print);
        }

        [Fact]
        void ShouldBeLetterA_WhenInputIsA()
        {
            var print = _diamond.Print('A');

            Assert.Equal("A", print);
        }

        [Fact]
        void ShouldprintUpperCaseDiamond_WhenInputIsLowerCase()
        {
            var print = _diamond.Print('a');

            Assert.Equal("A", print);
        }

        [Theory]
        [InlineData('A', 1)]
        void ShouldHave2TimesLetterPositionMinus1AsLineNumber(char letter, int lineNumber)
        {
            var print = _diamond.Print(letter);
            var lines = print.Split(Environment.NewLine);

            Assert.Equal(lineNumber, lines.Length);
        }
            
    }

}

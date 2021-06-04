using System;
using System.Linq;
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
        [InlineData('B', 3)]
        [InlineData('C', 5)]
        [InlineData('D', 7)]
        void ShouldHave2TimesLetterPositionMinus1AsLineNumber(char letter, int lineNumber)
        {
            var print = _diamond.Print(letter);
            var lines = print.Split(Environment.NewLine);

            Assert.Equal(lineNumber, lines.Length);
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        void ShouldHaveIncreasingLettersUntilInputLetter(char letter)
        {
            var print = _diamond.Print(letter);

            var lines = print.Split(Environment.NewLine).Take(letter - 'A' + 1).ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                Assert.Contains((char)('A' + i), lines[i].ToCharArray());
            }
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('C')]
        void ShouldHaveDecreasingLettersFromInputLetter(char letter)
        {
            var print = _diamond.Print(letter);

            var lines = print.Split(Environment.NewLine).Skip(letter - 'A').ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                Assert.Contains((char)(letter - i), lines[i].ToCharArray());
            }
        }
    }
}

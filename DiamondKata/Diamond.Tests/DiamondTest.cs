using FsCheck;
using FsCheck.Xunit;
using System;
using System.Linq;
using Xunit;

namespace Diamond.Tests
{
   
    public class DiamondTest
    {
        private Diamond diamond = new Diamond();
       [Fact]
       public void Should_Draw_A()
        {
            char c = 'A';

            Assert.Equal("A", diamond.Draw(c));
        }

        [Fact]
        public void ThrowsException_WhenInvalidCharacter()
        {
            char number = '1';

            Assert.Throws<ArgumentException>(() => diamond.Draw(number));
        }

        [Property(Arbitrary = new [] {typeof(NotALetterGenerator)})]
        public Property ThrowException_WhenNotLetter(char c)
        {
            var result = Record.Exception(() => diamond.Draw(c));

            return (result.GetType() == typeof(ArgumentException)).ToProperty();
        }


        [Property(Arbitrary = new[] { typeof(ALetterGenerator) })]
        public Property IsHorizontallySymetric(char c)
        {
            var result = diamond.Draw(c);
            var lines = result.Split(Environment.NewLine);

            return (string.Join(Environment.NewLine, lines.Reverse()) == result).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(ALetterGenerator) })]
        public Property FirstLineAndLastLineEqualA(char c)
        {
            var result = diamond.Draw(c);
            var lines = result.Split(Environment.NewLine);

            return (lines.FirstOrDefault().Contains('A') && lines.LastOrDefault().Contains('A')).ToProperty();
        }


    }

    internal static class NotALetterGenerator
    {
        public static Arbitrary<char> Generate()
        {
            return Arb.Default.Char().Filter(c => !char.IsLetter(c));
        }
    }

    internal static class ALetterGenerator
    {
        public static Arbitrary<char> Generate()
        {
            return Arb.Default.Char().Filter(c => char.IsLetter(c));
        }
    }
}

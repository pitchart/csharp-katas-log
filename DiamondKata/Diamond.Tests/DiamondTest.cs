using System;
using System.Linq;
using System.Threading.Tasks;
using FsCheck;
using FsCheck.Xunit;
using Xunit;
using Random = FsCheck.Random;

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
        public void ThrowsException_WhenInvalidCharacter()
        {
            char number = '_';

            Assert.Throws<ArgumentException>(() => diamond.Print(number));
        }

        [Property(Arbitrary = new[] { typeof(NotALetterGenerator) })]
        public Property ThrowsException_WhenNotALetter(char c)
        {
            var result = Record.Exception(() => diamond.Print(c));

            return (result.GetType() == typeof(ArgumentException)).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(ALetterGenerator) })]
        public Property FirstLineAndLastLineContainA(char c)
        {
            var result = diamond.Print(c);
            var lines = result.Split(Environment.NewLine);

            return (lines.FirstOrDefault().Contains('A') && lines.LastOrDefault().Contains('A')).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(ALetterGenerator) })]
        public Property IsHorizontallySymetric(char c)
        {
            var result = diamond.Print(c);
            var lines = result.Split(Environment.NewLine);

            return (string.Join(Environment.NewLine, lines.Reverse()) == result).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(ALetterGenerator) })]
        public Property EachLineContainsTwoLettersExceptFirstAndLast(char c)
        {
            var result = diamond.Print(c);
            var lines = result.Split(Environment.NewLine);
            lines = lines.Skip(1).SkipLast(1).Select(s => s.Replace(" ", "")).ToArray();
            return (lines.Select(l => l.Length).All(c => c == 2)).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(UpperLetterGenerator) })]
        public Property HasDecreasingToZeroLeftSpacesUntilInputCharLine(char c)
        {
            var result = diamond.Print(c);
            var lines = result.Split(Environment.NewLine);

            lines = lines.Take(c - 'A' + 1).ToArray();

            var spaces = lines.Select(s => s.TakeWhile(cc => cc.Equals(' '))).Select(s => s.Count());

            return spaces.SequenceEqual(Enumerable.Range(0, lines.Length).Reverse()).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(UpperLetterGenerator) })]
        public Property HasDecreasingToZeroRightSpacesUntilInputCharLine(char c)
        {
            var result = diamond.Print(c);
            var lines = result.Split(Environment.NewLine);

            lines = lines.Take(c - 'A' + 1).ToArray();

            var spaces = lines.Select(s => s.Reverse().TakeWhile(cc => cc.Equals(' '))).Select(s => s.Count());

            return spaces.SequenceEqual(Enumerable.Range(0, lines.Length).Reverse()).ToProperty();
        }
    }

    internal static class ALetterGenerator
    {
        public static Arbitrary<char> Generate()
        {
            return Arb.Default.Char().Filter(char.IsLetter);
        }
    }

    internal static class UpperLetterGenerator
    {
        public static Arbitrary<char> Generate()
        {
            return Arb.Default.Char().Filter(c => char.IsLetter(c) && char.IsUpper(c));
        }
    }

    internal static class NotALetterGenerator
    {
        public static Arbitrary<char> Generate()
        {
            return Arb.Default.Char().Filter(c => !char.IsLetter(c));
        }
    }
}

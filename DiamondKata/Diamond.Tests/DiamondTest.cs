using FsCheck;
using FsCheck.Xunit;
using System;
using System.Collections.Generic;
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

        [Property(Arbitrary = new[] { typeof(NotALetterGenerator) })]
        public Property ThrowException_WhenNotLetter(char c)
        {
            var result = Record.Exception(() => diamond.Draw(c));

            return (result.GetType() == typeof(ArgumentException)).ToProperty();
        }


        [Property(Arbitrary = new[] { typeof(AUpperLetterGenerator) })]
        public Property IsHorizontallySymetric(char c)
        {
            var result = diamond.Draw(c);
            var lines = result.Split(Environment.NewLine);

            return (string.Join(Environment.NewLine, lines.Reverse()) == result).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(AUpperLetterGenerator) })]
        public Property FirstLineAndLastLineEqualA(char c)
        {
            var result = diamond.Draw(c);
            var lines = result.Split(Environment.NewLine);

            return (lines.FirstOrDefault().Contains('A') && lines.LastOrDefault().Contains('A')).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(AUpperLetterGenerator) })]
        public Property EachLineMustContainsTwoLettersExceptFirstAndLast(char c)
        {
            var result = diamond.Draw(c);
            var lines = result.Split(Environment.NewLine);
            lines = lines.Skip(1).SkipLast(1).Select(s => s.Replace(" ", string.Empty)).ToArray();
            return (lines.Count(l => l.Length == 2) == lines.Length).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(AUpperLetterGenerator) })]
        public Property CheckLeftSpacesOfDiamond(char c)
        {
            var result = diamond.Draw(c);
            var lines = result.Split(Environment.NewLine);
            lines = lines.Take(char.ToUpper(c) - 'A' + 1).ToArray();
            var spaces = lines.Select(s => s.TakeWhile(cc => cc.Equals(' '))).Select(s => s.Count());
            return spaces.SequenceEqual(Enumerable.Range(0, lines.Length).Reverse()).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(AUpperLetterGenerator) })]
        public Property CheckRightSpacesOfDiamond(char c)
        {
            var result = diamond.Draw(c);
            var lines = result.Split(Environment.NewLine);
            lines = lines.Take(char.ToUpper(c) - 'A' + 1).ToArray();
            var spaces = lines.Select(s => s.Reverse().TakeWhile(cc => cc.Equals(' '))).Select(s => s.Count());
            return spaces.SequenceEqual(Enumerable.Range(0, lines.Length).Reverse()).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(AUpperLetterGenerator) })]
        public Property DiamondIsSquare(char c)
        {
            var result = diamond.Draw(c);
            var lines = result.Split(Environment.NewLine);
            return lines.All(line => line.Length.Equals(lines.Length)).ToProperty();
        }
    }

    internal static class NotALetterGenerator
    {
        public static Arbitrary<char> Generate()
        {
            return Arb.Default.Char().Filter(c => !char.IsLetter(c));
        }
    }

    internal static class AUpperLetterGenerator
    {
        public static Arbitrary<char> Generate()
        {
            return Arb.Default.Char().Filter(c => char.IsLetter(c) && char.IsUpper(c));
        }
    }
}

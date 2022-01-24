using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        private readonly Diamond diamond = new Diamond();

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
            return Prop.Throws<ArgumentException,string>(new Lazy<string>(()=> diamond.Print(c)));
        }

        [Property(Arbitrary = new[] { typeof(ALetterGenerator) })]
        public Property FirstLineAndLastLineContainA(char c)
        {
            string[] lines = ConstructLines(c);

            return (lines.First().Contains('A') && lines.Last().Contains('A')).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(ALetterGenerator) })]
        public Property IsHorizontallySymmetric(char c)
        {
            string[] lines = ConstructLines(c);
            return lines.SequenceEqual(lines.Reverse()).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(ALetterGenerator) })]
        public Property EachLineContainsTwoLettersExceptFirstAndLast(char c)
        {
            string[] lines = ConstructLines(c);
            lines = lines.Skip(1).SkipLast(1).Select(s => s.Replace(" ", "")).ToArray();
            return (lines.Select(l => l.Length).All(l => l == 2)).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(UpperLetterGenerator) })]
        public Property HasDecreasingToZeroLeftSpacesUntilInputCharLine(char c)
        {
            string[] lines = ConstructLines(c);
            lines = TakeUntilInput(lines, c);;

            var spaces = CountSpacesBeforeFirstLetter(lines);

            return spaces.SequenceEqual(Enumerable.Range(0, lines.Length).Reverse()).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(UpperLetterGenerator) })]
        public Property HasDecreasingToZeroRightSpacesUntilInputCharLine(char c)
        {
            string[] lines = ConstructLines(c);
            lines = TakeUntilInput(lines, c); 

            var spaces = CountSpacesAfterLastLetter(lines);

            return spaces.SequenceEqual(Enumerable.Range(0, lines.Length).Reverse()).ToProperty();
        }

        private string[] TakeUntilInput(IEnumerable<string> lines, char c)
        {
            return lines.Take(c - 'A' + 1).ToArray();
        }

        [Property(Arbitrary = new[] { typeof(ALetterGenerator) })]
        public Property DiamondIsSquare(char c)
        {
            string[] lines = ConstructLines(c);
            return lines.All(line => line.Length.Equals(lines.Length)).ToProperty();
        }

        private string[] ConstructLines(char c)
        {
            return diamond.Print(c).Split(Environment.NewLine);
        }

        private IEnumerable<int> CountSpacesBeforeFirstLetter(IEnumerable<string> lines)
        {
            return lines
                .Select(s => s.TakeWhile(cc => cc.Equals(' ')))
                .Select(s => s.Count())
                ;
        }

        private IEnumerable<int> CountSpacesAfterLastLetter(string[] lines)
        {
            return lines
                .Select(s => s.Reverse().TakeWhile(cc => cc.Equals(' ')))
                .Select(s => s.Count())
                ;
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

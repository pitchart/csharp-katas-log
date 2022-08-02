using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace Diamond.Tests
{

    public class DiamondTest
    {
        [Fact]
        public void Should_display_a_diamond_with_A()
        {
            //Act
            var result = Diamond.Display('A');

            //Assert
            result.Should().BeEquivalentTo("A");
        }

        [Property(Arbitrary = new[] { typeof(LetterGenerator) })]
        public void Should_have_input_as_letter_of_the_middle_line(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = SplitLines(result);
            var middleLine = lines[lines.Length / 2];
            middleLine.Should().Contain(letter.ToString());
        }

        [Property(Arbitrary = new[] { typeof(LetterGenerator) })]
        public void Should_have_A_as_first_letter(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var firstLine = SplitLines(result).First();
            firstLine.Should().Contain("A");
        }

        [Property(Arbitrary = new[] { typeof(LetterGenerator) })]
        public void Should_have_consecutive_letters(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = SplitLines(result).Select(FirstLetter);

            var expected = ListLettersUntil(letter);
            expected = AddLowerLettersTo(expected);
            lines.Should().BeEquivalentTo(expected);
        }

        [Property(Arbitrary = new[] { typeof(LetterGenerator) })]
        public void Should_have_a_decreasing_number_of_left_outer_spaces(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = SplitLines(result)
                .TakeWhile(line => !line.Contains(letter))
                .Select(x => x.ToCharArray().TakeWhile(c => c == ' ').Count());

            var expected = Enumerable.Range(1, (int)letter - 'A').Reverse();
            lines.Should().BeEquivalentTo(expected);
        }

        [Property(Arbitrary = new[] { typeof(LetterGenerator) })]
        public void Should_have_a_decreasing_number_of_right_outer_spaces(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = SplitLines(result)
                .Select(l => l.Reverse())
                .TakeWhile(line => !line.Contains(letter))
                .Select(x => x.TakeWhile(c => c == ' ').Count());

            var expected = Enumerable.Range(1, (int)letter - 'A').Reverse();
            lines.Should().BeEquivalentTo(expected);
        }

        [Property(Arbitrary = new[] { typeof(LetterGenerator) })]
        public void Should_have_an_increasing_number_of_inner_spaces(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lineInnerSpaces = SplitLines(result)
                .Reverse()
                .SkipWhile(line => !line.Contains(letter))
                .Reverse()
                .Select(line => line.Trim().Skip(1).SkipLast(1).Count());

            var expected = new List<int>() {0};
            for(var i = 0; i < lineInnerSpaces.Count()-1; i++)
            {
                expected.Add(i*2+1);
            }
            lineInnerSpaces.Should().BeEquivalentTo(expected);
        }

        private static char FirstLetter(string s)
        {
            return s.Trim(' ').First();
        }

        private static string[] SplitLines(string result)
        {
            return result.Split(Environment.NewLine);
        }

        private static IEnumerable<char> AddLowerLettersTo(IEnumerable<char> expected)
        {
            return expected.Concat(expected.Reverse().Skip(1));
        }

        private static IEnumerable<char> ListLettersUntil(char letter)
        {
            return Enumerable.Range((int)'A', (int)letter - 'A' + 1).Select(i => (char)i);
        }
    }

    public static class LetterGenerator
    {
        public static Arbitrary<char> Generate() =>
            Arb.Default.Char().Filter(c => c >= 'A' && c <= 'Z');
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using Xunit;
using static MoreLinq.Extensions.TakeUntilExtension;

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

        [LowerLetter]
        public void Should_have_input_as_letter_of_the_middle_line(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = SplitLines(result);
            var middleLine = MiddleOf(lines);

            middleLine.Should().Contain(letter.ToString());
        }

        [LowerLetter]
        public void Should_have_A_as_first_letter(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var firstLine = SplitLines(result).First();
            firstLine.Should().Contain("A");
        }

        [LowerLetter]
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

        [LowerLetter]
        public void Should_have_a_decreasing_number_of_left_outer_spaces(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            string[] lines = SplitLines(result);
            var outerSpaces = lines
                .TakeUntil(LineIsMiddleOf(lines))
                .Select(x => LeftSpaces(x).Count());

            var expected = OuterSpacesFor(letter);
            outerSpaces.Should().BeEquivalentTo(expected);
        }


        [LowerLetter]
        public void Should_have_a_decreasing_number_of_right_outer_spaces(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = SplitLines(result);
            var rightOuterSpaces = lines
                .TakeUntil(LineIsMiddleOf(lines))
                .Select(x => RightSpaces(x).Count());

            var expected = OuterSpacesFor(letter);
            rightOuterSpaces.Should().BeEquivalentTo(expected);
        }

        [LowerLetter]
        public void Should_have_an_increasing_number_of_inner_spaces(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = SplitLines(result);

            var lineInnerSpaces = lines
                .TakeUntil(LineIsMiddleOf(lines))
                .Select(line => InnerSpacesOf(line).Count());

            lineInnerSpaces.Should().BeEquivalentTo(ExpectedInnerSpacesFor(letter));
        }

        [LowerLetter]
        public void Should_have_horizontal_symmetry(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = SplitLines(result);

            var upperLines = lines.TakeUntil(LineIsMiddleOf(lines));
            var lowerLines = lines.Reverse().TakeUntil(LineIsMiddleOf(lines));

            upperLines.Should().BeEquivalentTo(lowerLines);
        }

        private Func<string, bool> LineIsMiddleOf(string[] lines) => line => line == MiddleOf(lines);

        private static IEnumerable<int> ExpectedInnerSpacesFor(char letter) => Enumerable.Range(0, (int)letter - 'A').Select(x => x * 2 + 1).Prepend(0);

        private static IEnumerable<char> InnerSpacesOf(string line) => line.Trim().Skip(1).SkipLast(1);

        private string MiddleOf(string[] lines) => lines[lines.Length / 2];

        private static char FirstLetter(string s) => s.Trim(' ').First();

        private static string[] SplitLines(string result) => result.Split(Environment.NewLine);

        private static IEnumerable<char> AddLowerLettersTo(IEnumerable<char> expected) => expected.Concat(expected.Reverse().Skip(1));

        private static IEnumerable<char> ListLettersUntil(char letter) => Enumerable.Range((int)'A', (int)letter - 'A' + 1).Select(i => (char)i);

        private static IEnumerable<char> LeftSpaces(string x) => x.ToCharArray().TakeWhile(c => c == ' ');

        private static IEnumerable<int> OuterSpacesFor(char letter) => Enumerable.Range(0, (int)letter - 'A' + 1).Reverse();

        private static IEnumerable<char> RightSpaces(string x) => x.Reverse().TakeWhile(c => c == ' ');
    }

    public static class LetterGenerator
    {
        public static Arbitrary<char> Generate() =>
            Arb.Default.Char().Filter(c => c >= 'D' && c <= 'F');
    }

    public class LowerLetterAttribute : PropertyAttribute
    {
        public LowerLetterAttribute()
        {
            Arbitrary = new[] { typeof(LetterGenerator) };
            MaxTest = 10;
        }
    }
}

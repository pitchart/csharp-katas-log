using System;
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
            var lines = result.Split(Environment.NewLine);
            var middleLine = lines[lines.Length / 2];
            middleLine.Should().Contain(letter.ToString());
        }

        [Property(Arbitrary = new[] { typeof(LetterGenerator) })]
        public void Should_have_A_as_first_letter(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = result.Split(Environment.NewLine);
            var firstLine = lines[0];
            firstLine.Should().Contain("A");
        }

        [Property(Arbitrary = new[] { typeof(LetterGenerator) })]
        public void Should_have_consecutive_letters(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = result
                .Split(Environment.NewLine)
                .Select(s => s.Trim(' '))
                .Select(s => s[0]);

            var expected = Enumerable.Range((int)'A', (int)letter - 'A' + 1).Select(i => (char)i);
            expected = expected.Concat(expected.Reverse().Skip(1));
            lines.Should().BeEquivalentTo(expected);
        }

        [Property(Arbitrary = new[] { typeof(LetterGenerator) })]
        public void Should_have_a_decreasing_number_of_outer_spaces(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = result
                .Split(Environment.NewLine)
                .TakeWhile(line => !line.Contains(letter))
                .Select(x => x.ToCharArray().TakeWhile(c => c == ' ').Count());

            var expected = Enumerable.Range(1, (int)letter - 'A').Reverse();
            lines.Should().BeEquivalentTo(expected);
        }
    }

    public static class LetterGenerator
    {
        public static Arbitrary<char> Generate() =>
            Arb.Default.Char().Filter(c => c >= 'A' && c <= 'Z');
    }
}

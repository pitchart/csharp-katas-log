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
            var lines = result.Split('\n');
            var middleLine = lines[lines.Length / 2];
            middleLine.Should().Contain(letter.ToString());
        }

        [Property(Arbitrary = new[] { typeof(LetterGenerator) })]
        public void Should_have_A_as_first_letter(char letter)
        {
            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = result.Split('\n');
            var firstLine = lines[0];
            firstLine.Should().Contain("A");
        }

        [Property(Arbitrary = new[] { typeof(LetterGenerator) })]
        public void Should_have_consecutive_letters(char letter)
        {
            //Arrange

            //Act
            var result = Diamond.Display(letter);

            //Assert
            var lines = result
                .Split('\n')
                .Select(s => s.Trim(' '))
                .Select(s => s[0]);

            var expected = new string[] {};
            lines.Should().BeEquivalentTo(expected);
        }
    }

    public static class LetterGenerator
    {
        public static Arbitrary<char> Generate() =>
            Arb.Default.Char().Filter(c => c >= 'A' && c <= 'Z');
    }
}

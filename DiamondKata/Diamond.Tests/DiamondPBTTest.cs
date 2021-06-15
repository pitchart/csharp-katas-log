using FsCheck;
using FsCheck.Xunit;

namespace Diamond.Tests
{

    public class DiamondPBTTest
    {
        private readonly DiamondPbt _diamond = new DiamondPbt();

        [Property(Arbitrary = new[] { typeof(NotALetterGenerator) })]
        public void Should_be_empty_when_input_is_not_a_letter(char notALetter)
        {
            _diamond.Print(notALetter).Equals(string.Empty).ToProperty();
        }

        [Property(Arbitrary = new[] { typeof(LowerCaseLetterGenerator) })]
        public void ShouldprintUpperCaseDiamond_WhenInputIsLowerCase(char lowerCaseLetter)
        {
            _diamond.Print(lowerCaseLetter).Equals(_diamond.Print(char.ToUpper(lowerCaseLetter))).ToProperty();
        }
    }

    public class UpperCaseLetterGenerator
    {
        public static Arbitrary<char> Generate() =>
            Arb.Default.Char().Filter(c => (c >= 'A' && c <= 'Z'));
    }

    public class LowerCaseLetterGenerator
    {
        public static Arbitrary<char> Generate() =>
            Arb.Default.Char().Filter(c => (c >= 'a' && c <= 'z'));
    }

    public class NotALetterGenerator
    {
        public static Arbitrary<char> Generate() =>
            Arb.Default.Char().Filter(c => (c < 'A' && c > 'Z') || (c < 'a' && c > 'z'));
    }
}

using FsCheck;
using FsCheck.Xunit;

namespace Diamond.Tests
{

    public class DiamondPBTTest
    {
        private readonly DiamondPbt _diamond = new DiamondPbt();

        [Property(Arbitrary = new[] {typeof(NotALetterGenerator)})]
        public void Should_be_empty_when_input_is_not_a_letter()
        {
            (_diamond.Print() == string.Empty).ToProperty();
        }
    }

    public class NotALetterGenerator
    {
        public static Arbitrary<char> Generate() =>
            Arb.Default.Char().Filter(c => (c < 'A' && c > 'Z') || (c < 'a' && c > 'z') );
    }

}

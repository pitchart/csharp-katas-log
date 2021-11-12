using System;

using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace Diamond.Tests
{

    public class DiamondTest
    {
        [Fact]
        public void AnEmptyInput_ShouldThrow()
        {
            new Diamond().Invoking(d => d.Generate('\0')).Should().Throw<ArgumentException>();
        }

        [Property(Arbitrary = new [] {typeof(AnythingButALetterGenerator)})]
        public Property ShouldNotAcceptAnythingButALetter(char notALetter)
        {
            var d = new Diamond();

            return Prop.Throws<ArgumentException, string>(new Lazy<string>(() => d.Generate(notALetter)));
        }
        
        [Fact]
        public void A_ShouldPrintA()
        {
            var d = new Diamond();

            d.Generate('A').Should().Be("A");
        }

        [Fact]
        public void B_ShouldPrintTheGoodResult()
        {
            // ARRANGE
            var diamond = new Diamond();

            // ACT
            string result = diamond.Generate('B');

            // ASSERT ==> " A \nB B\n A "
            result.Should().Be(" A \nB B\n A ");
        }
    }

    public static class AnythingButALetterGenerator
    {
        public static Arbitrary<char> Generate() => Arb.Default.Char().Filter(c => c < 'A' || c > 'Z');
    }

}

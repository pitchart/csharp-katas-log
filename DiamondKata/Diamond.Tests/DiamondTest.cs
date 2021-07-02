using System;

using FluentAssertions;

using Xunit;

namespace Diamond.Tests
{

    public class DiamondTest
    {
        [Fact]
        public void AnEmptyInput_ShouldThrow()
        {
            var action = new Action(() =>
            {
                var d = new Diamond();
                d.Generate('\0');
            });

            action.Should().Throw<ArgumentException>();
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
            result.Should().Be("A\nB\nA");
        }
    }
}

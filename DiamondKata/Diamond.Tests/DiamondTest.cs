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
    }
}

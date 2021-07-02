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
                d.Generate(String.Empty);
            });

            action.Should().Throw<ArgumentException>();
        }
    }
}

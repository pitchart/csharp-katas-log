using FluentAssertions;
using Xunit;

namespace TcrKata.Domain.Tests;

public class SubmarineTest
{
    private readonly Submarine submarine;

    public SubmarineTest()
    {
        this.submarine = new Submarine();
    }

    [Fact]
    public void SomeFakeTest()
    {
        this.submarine.Should().NotBeNull();
    }
}
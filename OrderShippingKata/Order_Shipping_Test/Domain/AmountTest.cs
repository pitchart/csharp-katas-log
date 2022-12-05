using Xunit;
using FluentAssertions;
using OrderShipping.Domain;

namespace OrderShippingTest.Domain;

public class AmountTest
{
    [Fact]
    public void Should_add_amount()
    {
        var amount1 = new Amount(1);
        var amount2 = new Amount(2);

        Amount sumAmount = amount1 + amount2;

        decimal expected = 3m;
        sumAmount.Should().Be(new Amount(3));
        (sumAmount == expected).Should().BeTrue();
    }
    
    [Fact]
    public void Should_multiply_amount()
    {
        var amount = new Amount(2);

        Amount sumAmount = amount * 3;

        sumAmount.Should().Be(new Amount(6));
    }
    
    [Fact]
    public void Should_divide_amount()
    {
        var amount = new Amount(4);

        Amount sumAmount = amount / 2;

        sumAmount.Should().Be(new Amount(2));
    }
    
    [Fact]
    public void Should_round_amount()
    {
        var amount = new Amount(4.989998m);

        Amount sumAmount = amount.Round();

        sumAmount.Should().Be(new Amount(4.99m));
    }
}

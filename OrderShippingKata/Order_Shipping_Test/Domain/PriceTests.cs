using FluentAssertions;
using Order_Shipping.Domain;
using Xunit;

namespace OrderShippingTest.Domain;

public class PriceTests
{
    [Fact]
    public void Round()
    {
        // Arrange
        var price = new Price(3.123m, "EUR");

        // Act
        var rounded = price.Round();

        // Assert
        rounded.Should().Be(new Price(3.13m, "EUR"));

    }

    // Ajout de prix
    [Fact]
    public void AddPrice()
    {
        Assert.True(false);

    }
    // Multiplier par un entier

    // Prendre un pourcentage
}

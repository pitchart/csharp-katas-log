using FluentAssertions;
using Order_Shipping.Domain;
using System;
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

    [Fact]
    public void AddPrice()
    {
        // Arrange
        var price = new Price(3.12m, "EUR");
        var price2 = new Price(2.15m, "EUR");

        // Act
        var sum = price + price2;

        // Assert
        sum.Should().Be(new Price(5.27m, "EUR"));
        price.Should().Be(new Price(3.12m, "EUR"));
    }

    [Fact]
    public void AddPriceWithDifferentCurrencies()
    {
        // Arrange
        var price = new Price(3.12m, "EUR");
        var price2 = new Price(2.15m, "USD");

        // Act
        var sum = () => price + price2;

        // Assert
        sum.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void MultiplyPrice()
    {
        // Arrange
        var price = new Price(3.5m, "EUR");

        // Act
        var result = price * 2;

        // Assert
        result.Should().Be(new Price(7m, "EUR"));
    }

    [Fact]
    public void MultiplyPriceInverse()
    {
        // Arrange
        var price = new Price(3.5m, "EUR");

        // Act
        var result = 2 * price;

        // Assert
        result.Should().Be(new Price(7m, "EUR"));
    }

    [Fact]
    public void Tax()
    {
        // Arrange
        var price = new Price(200m, "EUR");

        // Act
        var result = price.GetTax(5.5m);

        // Assert
        result.Should().Be(new Price(11m, "EUR"));
    }

    [Fact]
    public void PriceEqual()
    {
        // Arrange
        var price = new Price(34m, "EUR");

        // Act
        var result = price == 34m;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void PriceEqualInverse()
    {
        // Arrange
        var price = new Price(34m, "EUR");

        // Act
        var result = 34m == price;

        // Assert
        result.Should().BeTrue();
    }
}

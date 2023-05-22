using OrderShipping.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace OrderShippingTest.Domain;

public class OrderTests
{
    [Fact]
    public void should_throw_exception_when_order_is_constructed_with_null_or_empty_order_lines()
    {
        Assert.Throws<InvalidOperationException>(() => new Order("EUR", null));
        Assert.Throws<InvalidOperationException>(() => new Order("EUR", new List<OrderItem>()));
    }
}

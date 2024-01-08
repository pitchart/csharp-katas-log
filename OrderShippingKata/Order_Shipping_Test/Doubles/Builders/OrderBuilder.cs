using Order_Shipping.Domain;
using OrderShipping.Domain;
using System.Collections.Generic;

namespace OrderShippingTest.Doubles.Builders;

public class OrderBuilder
{
    private OrderState _state;
    public string _currency;
    public IList<OrderItem> _items;
    public int _id;

    public OrderBuilder ANewOrder();
    public OrderBuilder ARejectedOrder();
    public OrderBuilder AnApprovedOrder();
    public OrderBuilder AShippedOrder();
}

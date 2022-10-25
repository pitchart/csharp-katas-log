using OrderShipping.Domain;
using System.Collections.Generic;

namespace OrderShippingTest.Doubles.Builder
{
    public class OrderBuilder
    {
        private int _id = 1;
        private OrderStatus _status = OrderStatus.Created;
        private string _currency = "EUR";
        private IList<OrderItem> _items = new List<OrderItem>();

        private OrderBuilder() { }


        public OrderBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public OrderBuilder WithStatus(OrderStatus status)
        {
            _status = status;
            return this;
        }

        public OrderBuilder WithCurrency(string currency)
        {
            _currency = currency;
            return this;
        }

        public OrderBuilder WithItems(IList<OrderItem> items)
        {
            _items = items;
            return this;
        }

        public Order Build()
        {
            return new Order
            {
                Id = _id,
                Status = _status,
            };
        }

        public static OrderBuilder ANewOrder() => new() { _status = OrderStatus.Created };

        public static OrderBuilder ARejectedOrder() => new() { _status = OrderStatus.Rejected };

        public static OrderBuilder AnApprovedOrder() => new() { _status = OrderStatus.Approved };

        public static OrderBuilder AShippedOrder() => new() { _status = OrderStatus.Shipped };
    }
}

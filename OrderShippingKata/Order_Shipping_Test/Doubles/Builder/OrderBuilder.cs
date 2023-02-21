using OrderShipping.Domain;
using System.Collections.Generic;

namespace OrderShippingTest.Doubles.Builder
{
    public class OrderBuilder
    {
        private int _id = 1;
        private OrderStatusEnum _statusEnum = OrderStatusEnum.Created;
        private string _currency = "EUR";
        private IList<OrderItem> _items = new List<OrderItem>();

        private OrderBuilder() { }


        public OrderBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public OrderBuilder WithStatus(OrderStatusEnum statusEnum)
        {
            _statusEnum = statusEnum;
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
                StatusEnum = _statusEnum,
            };
        }

        public static OrderBuilder ANewOrder() => new() { _statusEnum = OrderStatusEnum.Created };

        public static OrderBuilder ARejectedOrder() => new() { _statusEnum = OrderStatusEnum.Rejected };

        public static OrderBuilder AnApprovedOrder() => new() { _statusEnum = OrderStatusEnum.Approved };

        public static OrderBuilder AShippedOrder() => new() { _statusEnum = OrderStatusEnum.Shipped };
    }
}

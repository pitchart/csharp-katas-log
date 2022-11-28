﻿using OrderShipping.Domain;
using OrderShipping.Service;

namespace OrderShippingTest.Doubles
{
    public class TestShipmentService : IShipmentService
    {
        private Order _shippedOrder = null;

        public void Ship(Order order)
        {
            _shippedOrder = order;
        }

        public Order GetShippedOrder()
        {
            return _shippedOrder;
        }
    }
}
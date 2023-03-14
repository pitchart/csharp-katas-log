using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderShipping.Domain;

namespace Order_Shipping.Domain
{
    public abstract class OrderStatus
    {
        public static OrderStatus Create(OrderStatusEnum orderStatusEnum)
        {
            return orderStatusEnum switch
            {
                OrderStatusEnum.Approved =>  new OrderApproved(),
                OrderStatusEnum.Shipped =>  new OrderShipped(),
                OrderStatusEnum.Rejected =>  new OrderRejected(),
                _ => new OrderCreated(),
            };
        }

        public abstract void Approve(Order order);

        public abstract void Reject(Order order);
        
        public abstract void Ship(Order order);
        
        public abstract OrderStatusEnum GetOrderStatusEnum();
    }
}

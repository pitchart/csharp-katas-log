using OrderShipping.Domain;

namespace Order_Shipping.Domain
{
    public interface OrderStatus
    {
        public void Approve(Order order);

        public void Reject(Order order);

        public void Ship(Order order);
    }
}

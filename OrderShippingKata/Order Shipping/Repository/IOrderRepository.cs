using OrderShipping.Domain;

namespace OrderShipping.Repository
{
    public interface IOrderRepository
    {
        void Save(Order order);
        Order GetById(int orderId);
    }
}
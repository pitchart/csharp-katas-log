using OrderShipping.Domain;

namespace OrderShipping.Service
{
    public interface IShipmentService
    {
        void Ship(Order order);
    }
}
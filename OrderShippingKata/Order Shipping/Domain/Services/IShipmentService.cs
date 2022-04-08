namespace OrderShipping.Domain.Services
{
    // Voir l'ADR "exception-pure-domain.md"
    public interface IShipmentService
    {
        void Ship(Order order);
    }
}

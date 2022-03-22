using OrderShipping.Domain;

namespace OrderShipping.Repository
{
    public interface IProductCatalog
    {
        Product GetByName(string name);
    }
}
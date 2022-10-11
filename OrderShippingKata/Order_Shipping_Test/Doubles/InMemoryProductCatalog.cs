using OrderShipping.Domain;
using OrderShipping.Repository;
using System.Collections.Generic;
using System.Linq;

namespace OrderShippingTest.Doubles
{
    public class InMemoryProductCatalog : IProductCatalog
    {
        private readonly IList<Product> _products;

        public InMemoryProductCatalog(IList<Product> products)
        {
            _products = products;
        }

        public Product GetByName(string name)
        {
            return _products.FirstOrDefault(p => p.Name == name);
        }
    }
}
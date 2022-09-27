using OrderShipping.Domain;
using Xunit;

namespace OrderShippingTest
{
    public class ProductTests
    {
        [Fact]
        public void Should_Calculate_Unitary_Tax()
        {
            var food = new Category
            {
                Name = "food",
                TaxPercentage = 10m
            };

            Product product = new("Salad", 100m, food);

            Assert.Equal(10, product.UnitaryTax);
        }

        [Fact]
        public void Should_Calculate_Unitary_Tax_Amount()
        {
            var food = new Category
            {
                Name = "food",
                TaxPercentage = 10m
            };

            Product product = new("Salad", 100m, food);

            Assert.Equal(110, product.UnitaryTaxedAmount);
        }
    }
}

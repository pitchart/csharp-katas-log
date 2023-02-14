namespace CupCake;

public class Bundle : IProduct
{
    private readonly IEnumerable<IProduct> _products;

    public Bundle(IProduct product, params IProduct[] products)
    {
        _products = products.ToList().Prepend(product);
    }

    public string GetName()
    {
        var productComposition = _products
            .Select(product => product.GetName())
            .GroupBy(name => name)
            .Select(ProductNameWithNumbers());
        return $"📦 composed of {string.Join(" and ", productComposition)}";
    }

    private static Func<IGrouping<string, string>, string> ProductNameWithNumbers()
    {
        return groupedProduct => $"{groupedProduct.Count()} {groupedProduct.Key}";
    }

    public string GetFormatedPrice()
    {
        return $"{GetPrice():N2}$".Replace(',', '.');
    }

    public float GetPrice()
    {
        return (_products.Sum(product => product.GetPrice()) * 0.9f);
    }
}

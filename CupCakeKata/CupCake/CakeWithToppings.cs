namespace CupCake;

public class CakeWithToppings : ICakeWithToppings
{
    protected readonly IProduct Product;

    private readonly string _toppings;

    private readonly float _price;

    public CakeWithToppings(string toppings, IProduct product, float price)
    {
        _toppings = toppings;
        Product = product;
        _price = price;
    }

    public string GetName()
    {
        string @operator = Product is ICakeWithToppings ? "and" : "with";
        return $"{Product.GetName()} {@operator} {_toppings}";
    }

    public float GetPrice()
    {
        return _price + Product.GetPrice();
    }

    public string GetFormatedPrice()
    {
        float price = GetPrice();
        return $"{price}$".Replace(',', '.');
    }
}

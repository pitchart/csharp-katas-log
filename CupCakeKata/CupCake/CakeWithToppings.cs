namespace CupCake;

public class CakeWithToppings : ICakeWithToppings
{
    protected readonly ICakeBase _cakeBase;

    private readonly string _toppings;

    private readonly float _price;

    public CakeWithToppings(string toppings, ICakeBase cakeBase, float price)
    {
        _toppings = toppings;
        _cakeBase = cakeBase;
        _price = price;
    }

    public string GetName()
    {
        string @operator = _cakeBase is ICakeWithToppings ? "and" : "with";
        return $"{_cakeBase.GetName()} {@operator} {_toppings}";
    }

    public float GetPrice()
    {
        return _price + _cakeBase.GetPrice();
    }

    public string GetFormatedPrice()
    {
        float price = GetPrice();
        return $"{price}$".Replace(',', '.');
    }
}
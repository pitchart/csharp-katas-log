namespace CupCake;

public class Bundle
{
    private readonly ICakeBase _cakeBase;

    public Bundle(ICakeBase cakeBase)
    {
        _cakeBase = cakeBase;
    }

    public string GetName()
    {
        return $"📦 composed of {_cakeBase.GetName()}";
    }

    public string GetFormatedPrice()
    {
        float price = _cakeBase.GetPrice() * 0.9f;
        return $"{price}$".Replace(',', '.');
    }
}

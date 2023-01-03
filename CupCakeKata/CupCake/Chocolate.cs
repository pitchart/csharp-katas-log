namespace CupCake;

public class Chocolate
{
    public readonly CupCake cupCakeWrapper;

    public Chocolate(CupCake cupCake)
    {
        cupCakeWrapper = cupCake;
    }

    public string GetName()
    {
        return $"{cupCakeWrapper.GetName()} with 🍫";
    }

    public float GetUnitPrice()
    {
        return 0.1f;
    }

    public string GetPrice()
    {
        float price = cupCakeWrapper.GetUnitPrice() + GetUnitPrice();
        return $"{price}$".Replace(',', '.');
    }
}

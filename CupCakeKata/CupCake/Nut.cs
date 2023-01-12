namespace CupCake;

public class Nut
{
    public readonly Chocolate Chocolate;

    public Nut(Chocolate chocolate)
    {
        Chocolate = chocolate;
    }

    public string GetName()
    {
        return $"{Chocolate.GetName()} and 🥜";
    }

    public float GetPrice()
    {
        return 0.2f + Chocolate.GetPrice();
    }

    public string GetFormatedPrice()
    {
        float price = GetPrice();
        return $"{price}$".Replace(',', '.');
    }
}

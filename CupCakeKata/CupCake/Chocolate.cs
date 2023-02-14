namespace CupCake;

public class Chocolate : CakeWithToppings
{
    public Chocolate(IProduct product) : base("🍫", product, 0.1f)
    {
    }
}

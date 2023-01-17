namespace CupCake;

public class Chocolate : CakeWithToppings
{
    public Chocolate(ICakeBase cakeBase) : base("🍫", cakeBase, 0.1f)
    {
    }
}

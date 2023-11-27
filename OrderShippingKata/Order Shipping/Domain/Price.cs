namespace Order_Shipping.Domain;

public record Price(decimal Amount, string Currency)
{
    public Price Round()
    {
        return new Price(Round(Amount), Currency);
    }

    private static decimal Round(decimal amount)
    {
        return decimal.Round(amount, 2, MidpointRounding.ToPositiveInfinity);
    }

}

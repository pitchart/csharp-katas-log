namespace Order_Shipping.Domain;

public class Amount
{
    private readonly decimal _amount;

    public Amount(decimal amount)
    {
        _amount = amount;
    }

    public decimal RoundedValue => decimal.Round(_amount, 2, MidpointRounding.ToPositiveInfinity);

    public static Amount operator /(Amount amount, decimal value) => new(amount._amount / value);
    public static Amount operator +(Amount amount, Amount other) => new(amount._amount + other._amount);
    public static Amount operator *(Amount amount, decimal value) => new(amount._amount * value);
}

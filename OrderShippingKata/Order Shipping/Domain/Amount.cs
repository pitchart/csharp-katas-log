namespace Order_Shipping.Domain;

public class Amount : IEquatable<Amount>, IEquatable<decimal>
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
    public static bool operator !=(Amount amount, decimal value) => amount.RoundedValue != value;
    public static bool operator !=(decimal value, Amount amount) => amount.RoundedValue != value;
    public static bool operator ==(Amount amount, decimal value) => amount.RoundedValue == value;
    public static bool operator ==(decimal value, Amount amount) => amount.RoundedValue == value;

    public override bool Equals(object obj)
    {
        return obj switch
        {
            decimal @decimal => Equals(@decimal),
            Amount amount => Equals(amount),
            _ => false
        };
    }

    public override int GetHashCode()
    {
        return _amount.GetHashCode();
    }

    public bool Equals(Amount? amount)
    {
        if (amount is null)
        {
            return false;
        }
        return RoundedValue == amount.RoundedValue;
    }

    public bool Equals(decimal @decimal)
    {
        return RoundedValue == @decimal;
    }
}

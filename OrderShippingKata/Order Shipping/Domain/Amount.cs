namespace OrderShipping.Domain;

public record Amount(decimal _value)
{
    private decimal _value { get; init; } = _value;

    public static Amount operator +(Amount amount1, Amount amount2)
    {
        var value = amount1._value + amount2._value;
        return new Amount(value);
    }
    
    public static implicit operator decimal(Amount amount)
    {
        return amount._value;
    }
    
    public static implicit operator Amount(decimal d)
    {
        return new Amount(d);
    }

    public Amount Round()
    {
        var t = decimal.Round(this._value, 2, MidpointRounding.ToPositiveInfinity);
        return new Amount(t);
    }
}

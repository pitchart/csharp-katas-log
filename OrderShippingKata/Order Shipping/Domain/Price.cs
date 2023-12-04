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

    public Price Add(Price price2)
    {
        if (Currency != price2.Currency)
        {
            throw new InvalidOperationException();
        }
        return this with { Amount = Amount + price2.Amount };
    }

    public static Price operator +(Price price, Price price2) => price.Add(price2);

    public Price Multiply(decimal by)
    {
        return this with { Amount = Amount * by };
    }

    public static Price operator *(Price price, decimal by) => price.Multiply(by);

    public static Price operator *(decimal by, Price price) => price.Multiply(by);

    public Price GetTax(decimal tax)
    {
        return this with { Amount = Amount / 100 * tax };
    }

    public bool Equals(decimal amount)
    {
        return Amount == amount;
    }

    public static bool operator ==(Price price, decimal amount) => price.Equals(amount);

    public static bool operator !=(Price price, decimal amount) => !price.Equals(amount);

    public static bool operator ==(decimal amount, Price price) => price.Equals(amount);

    public static bool operator !=(decimal amount, Price price) => !price.Equals(amount);
}

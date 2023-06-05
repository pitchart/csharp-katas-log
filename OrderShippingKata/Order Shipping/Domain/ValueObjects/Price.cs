﻿namespace OrderShipping.Domain.ValueObjects;

public record Price(decimal UnitaryPrice, string Currency)
{
    public decimal Round()
    {
        return decimal.Round(UnitaryPrice, 2, System.MidpointRounding.ToPositiveInfinity);
    }

    public static Price operator *(int a, Price b)
        => b * a;

    public static Price operator *(Price b, int a)
        => new Price(b.UnitaryPrice * a, b.Currency);

    public static Price operator +(Price b, Price a)
        => a.Currency == b.Currency ? 
            new Price(b.UnitaryPrice + a.UnitaryPrice, b.Currency) :
            throw new InvalidOperationException("Prices with different currencies cannot be added");

    public Price ApplyTax(int v)
    {
        return new Price((UnitaryPrice * v)/100, Currency);
    }
}

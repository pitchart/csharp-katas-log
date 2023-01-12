﻿namespace CupCake;

public class Chocolate
{
    public readonly ICake CakeWrapper;

    public Chocolate(ICake cake)
    {
        CakeWrapper = cake;
    }

    public string GetName()
    {
        return $"{CakeWrapper.GetName()} with 🍫";
    }

    public float GetPrice()
    {
        return 0.1f + CakeWrapper.GetPrice();
    }

    public string GetFormatedPrice()
    {
        float price = GetPrice();
        return $"{price}$".Replace(',', '.');
    }
}

namespace Order_Shipping.Domain
{
    public static class PriceHelper
    {
        public static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}

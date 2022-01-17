using System;

namespace Banking
{

    public class Amount
    {
        public decimal Value { get; }

        public Amount(decimal value)
        {
            this.Value = value >= 0 ? value : throw new Exception("Amount should not be negative.");
        }

        public static Amount operator +(Amount first, Amount second) => new Amount(first.Value + second.Value);

        public static Amount operator -(Amount first, Amount second) => new Amount(first.Value - second.Value);
    }

}

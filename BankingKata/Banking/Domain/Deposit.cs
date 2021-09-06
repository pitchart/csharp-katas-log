using System;

namespace Banking.Domain
{
    internal class Deposit : ITransaction
    {
        public DateTime Date { get; }
        public float Value { get; }

        public Deposit(DateTime date, int value)
        {
            this.Date = date;
            this.Value = value;
        }
    }
}

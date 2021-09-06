using System;

namespace Banking.Domain
{

    internal class Withdrawal : ITransaction
    {
        public DateTime Date { get; }
        public float Value { get; }

        public Withdrawal(DateTime date, int value)
        {
            this.Date = date;
            this.Value = value;
        }
    }

}

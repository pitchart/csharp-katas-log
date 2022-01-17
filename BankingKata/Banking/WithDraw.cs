using System;

namespace Banking
{
    public class WithDraw : ITransaction
    {
        public WithDraw(Amount amount, DateTime date, Amount balance)
        {
            Amount = amount;
            Date = date;
            Balance = balance - amount;
        }

        public Amount Amount { get; }

        public DateTime Date { get; }

        public Amount Balance { get; set;  }
    }
}

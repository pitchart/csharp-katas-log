using System;

namespace Banking
{
    public class WithDraw : ITransaction
    {  
        public WithDraw(decimal amount, DateTime date, decimal balance)
        {
            Amount = amount;
            Date = date;
            Balance = balance - amount;
        }

        public WithDraw(Amount amount, DateTime date, decimal balance)  : this((decimal) amount.Value, date, balance)
        {
        }

        public decimal Amount { get; }

        public DateTime Date { get; }

        public decimal Balance { get; set;  }
    }
}

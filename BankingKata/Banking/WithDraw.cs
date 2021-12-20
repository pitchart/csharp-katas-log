using System;

namespace Banking
{
    public class WithDraw : ITransaction
    {  
        public WithDraw(decimal amount, DateTime actionTime, decimal balance)
        {
            Amount = amount;
            Date = actionTime;
            Balance = balance - amount;
        }

        public decimal Amount { get; }

        public DateTime Date { get; }

        public decimal Balance { get; set;  }
    }
}

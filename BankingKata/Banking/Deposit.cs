using System;

namespace Banking
{

    public class Deposit : ITransaction
    {
       
        public Deposit(decimal amount, DateTime actionTime, decimal balance)
        {
            this.Amount = amount;
            this.Date = actionTime;
            this.Balance = balance + amount;
        }

        public decimal Amount { get; }

        public DateTime Date { get; }

        public decimal Balance { get; }
    }

}

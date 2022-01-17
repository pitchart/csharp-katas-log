using System;

namespace Banking
{

    public class Deposit : ITransaction
    {
        public Deposit(Amount amount, DateTime date, Amount balance) 
        {
            this.Amount = amount;
            this.Date = date;
            this.Balance = balance + amount;
        }

        public Amount Amount { get; }

        public DateTime Date { get; }

        public Amount Balance { get; set; }
    }

}

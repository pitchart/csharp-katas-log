using System;

namespace Banking
{

    public class Deposit : ITransaction
    {
       
        public Deposit(decimal amount, DateTime date, decimal balance)
        {
            this.Amount = amount;
            this.Date = date;
            this.Balance = balance + amount;
        }

        public Deposit(Amount amount, DateTime date, decimal balance) : this((decimal) amount.Value, date, balance)
        {
        }

        public decimal Amount { get; }

        public DateTime Date { get; }

        public decimal Balance { get; set; }
    }

}

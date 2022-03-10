using System;

namespace Banking
{
    internal class Deposite : ITransaction
    {
        public decimal Balance { get; }

        public DateTime Date { get; }

        public decimal Amount { get; }

        public Deposite(DateTime date, decimal amount, decimal balance)
        {
            Date = date;
            Amount = amount;
            Balance = balance + amount;
        }
    }
}

using System;

namespace Banking
{
    internal class Withdrawal : ITransaction
    {

        public DateTime Date { get; }

        public decimal Amount { get; }

        public decimal Balance { get; }

        public Withdrawal(DateTime date, decimal amount, decimal balance)
        {
            Date = date;
            Amount = amount;
            Balance = balance - amount;
        }

    }
}

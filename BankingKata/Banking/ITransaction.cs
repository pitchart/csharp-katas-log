using System;

namespace Banking
{
    public interface ITransaction
    {
        decimal Balance { get; }

        DateTime Date { get; }

        public decimal Amount { get; }
    }
}

using System;

namespace Banking
{

    public interface ITransaction
    {
        decimal Amount { get; }

        DateTime Date { get; }
        decimal Balance { get; }
    }

}

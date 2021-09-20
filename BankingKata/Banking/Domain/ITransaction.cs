using System;

namespace Banking.Domain
{

    public interface ITransaction
    {
        DateTime Date { get; }

        float Value { get; }

        float Balance { get; }
    }

}

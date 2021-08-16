using System;

namespace Banking
{

    public interface ITransaction
    {
        DateTime Date { get; }

        float Value { get; }
    }

}

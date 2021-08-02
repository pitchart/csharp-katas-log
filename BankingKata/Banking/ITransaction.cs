using System;

namespace Banking
{

    internal interface ITransaction
    {
        DateTime Date { get; }

        float Value { get; }
    }

}

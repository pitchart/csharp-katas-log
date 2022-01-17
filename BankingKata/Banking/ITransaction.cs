using System;

namespace Banking
{

    public interface ITransaction
    {
        Amount Amount { get; }

        DateTime Date { get; }
        Amount Balance { get; set; }
    }

}

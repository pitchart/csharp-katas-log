using System.Collections.Generic;

namespace Banking
{
    public class Statement
    {
        public readonly IEnumerable<Transaction> Transactions;
        public Statement(IList<Transaction> transactions)
        {
            Transactions = transactions;
        }
    }
}

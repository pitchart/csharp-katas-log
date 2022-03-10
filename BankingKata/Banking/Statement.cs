using System.Collections.Generic;

namespace Banking
{
    public class Statement
    {
        public readonly IEnumerable<ITransaction> Transactions;
        public Statement(IList<ITransaction> transactions)
        {
            Transactions = transactions;
        }
    }
}

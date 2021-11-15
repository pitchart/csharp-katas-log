using System.Collections.Generic;

namespace Banking
{

    public class Statement
    {
        private IList<ITransaction> _transactions;

        public Statement(IList<ITransaction> transactions)
        {
            _transactions = transactions;
        }

        public IList<ITransaction> GetTransactions()
        {
            return _transactions;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Domain
{

    public class DepositFilter : IFilter
    {
        public IList<ITransaction> Filter(IList<ITransaction> transactions)
        {
            return transactions.Where(t => t is Deposit).ToList();
        }
    }

}

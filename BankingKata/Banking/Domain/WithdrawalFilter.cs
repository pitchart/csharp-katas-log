using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Domain
{

    public class WithdrawalFilter : IFilter
    {
        public IList<ITransaction> Filter(IList<ITransaction> transactions)
        {
            return transactions.Where(t => t is Withdrawal).ToList();
        }
    }

}

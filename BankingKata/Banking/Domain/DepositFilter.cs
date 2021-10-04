using System;
using System.Collections.Generic;

namespace Banking.Domain
{

    public class DepositFilter : IFilter
    {
        public IList<ITransaction> Filter(IList<ITransaction> transactions)
        {
            throw new NotImplementedException();
        }
    }

}

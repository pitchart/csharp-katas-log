using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;

namespace Banking.Domain
{
    public class Statement
    {
        private readonly ImmutableList<ITransaction> _transactions;

        public Statement(List<ITransaction> transactions)
        {
            _transactions = transactions.OrderByDescending(transaction => transaction.Date).ToImmutableList();
        }

        public ImmutableList<ITransaction> Transactions { get => _transactions; }
    }
}

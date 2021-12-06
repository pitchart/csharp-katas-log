using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking
{

    public class Account
    {
        private IList<ITransaction> _transactions = new List<ITransaction>();

        public Statement GetStatement()
        {
            return new Statement(_transactions);
        }


        public void Deposit(int amount, DateTime actionTime)
        {
            _transactions.Add(new Deposit(amount, actionTime, Balance()));
        }

        private decimal Balance()
        {
            var latestTansaction = _transactions.LastOrDefault();

            return latestTansaction?.Balance ?? 0;
        }

        public void Withdraw(int amount, DateTime actionTime)
        {
            _transactions.Add(new WithDraw(amount, actionTime, Balance()));
        }
    }

}

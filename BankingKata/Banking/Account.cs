using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace Banking
{

    public class Account
    {
        private SortedList<DateTime, ITransaction> _transactions = new SortedList<DateTime, ITransaction>(Comparer<DateTime>.Create(
            (d1, d2) => -DateTime.Compare(d1, d2)));

        public Statement GetStatement()
        {
            return new Statement(_transactions.Values);
        }


        public void Deposit(int amount, DateTime actionTime)
        {
            _transactions.Add(actionTime, new Deposit(amount, actionTime, Balance()));
        }

        private decimal Balance()
        {
            var latestTransaction = _transactions.Values.LastOrDefault();

            return latestTransaction?.Balance ?? 0;
        }
        
        private decimal Balance(DateTime actionTime)
        {
            IEnumerable<KeyValuePair<DateTime,ITransaction>> keyValuePairs = _transactions.SkipWhile(pair => DateTime.Compare(pair.Key, actionTime) >= 0).ToList();
            var beforeTransaction = keyValuePairs.Select(t => t.Value).LastOrDefault();
            
            return beforeTransaction?.Balance ?? 0; 
        }

        public void Withdraw(int amount, DateTime actionTime)
        {
            _transactions.Add(actionTime, new WithDraw(amount, actionTime, Balance(actionTime)));
        }
    }

}

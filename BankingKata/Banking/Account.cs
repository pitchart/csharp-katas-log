using System;
using System.Collections.Generic;
using System.Linq;

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
        
        public void Deposit(Amount amount, DateTime date)
        {
            _transactions.Add(date, new Deposit(amount, date, Balance(date)));
            if (_transactions.Any(x=>x.Key < date))
                CalculateBalances(date);
        }

        private Amount Balance(DateTime actionTime)
        {
            IEnumerable<KeyValuePair<DateTime,ITransaction>> keyValuePairs = _transactions.SkipWhile(pair => DateTime.Compare(pair.Key, actionTime) >= 0).ToList();
            ITransaction beforeTransaction = keyValuePairs.Select(t => t.Value).FirstOrDefault();
            
            return beforeTransaction?.Balance ?? new Amount(0); 
        }

        public void Withdraw(Amount amount, DateTime date)
        {
            _transactions.Add(date, new WithDraw(amount, date, Balance(date)));
            
            if (_transactions.Any(x=>x.Key < date))
                CalculateBalances(date);
        }

        private void CalculateBalances(DateTime actionTime)
        {
            foreach (KeyValuePair<DateTime, ITransaction> transaction in _transactions.Where(x=> x.Value.Date > actionTime).Reverse())
            {
                Amount previousBalance = Balance(transaction.Key);
                transaction.Value.Balance = transaction.Value is WithDraw ? previousBalance - transaction.Value.Amount : previousBalance + transaction.Value.Amount ;
            }
        }
    }
}

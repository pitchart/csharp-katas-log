using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    public class Account
    {
        private List<ITransaction> Transactions = new List<ITransaction>();

        public void Deposite(decimal amount, DateTime date)
        {
            Transactions.Add(new Deposite(date,amount,GetBalance()));
        }

        private decimal GetBalance()
        {
            return Transactions.OrderByDescending(t => t.Date).FirstOrDefault()?.Balance ?? 0;
        }

        public Statement GetStatement()
        {
            return new Statement(Transactions);
        }

        public void WithDraw(decimal amount, DateTime date)
        {
            Transactions.Add(new Withdrawal(date, amount, GetBalance()));
        }

        public Statement GetDepositeStatement()
        {
            return new Statement(Transactions.Where(transaction => transaction is Deposite).ToList());
        }
    }
}

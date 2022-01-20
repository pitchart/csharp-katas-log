using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    public class Account
    {
        private List<Transaction> Transactions = new List<Transaction>();

        public void Deposite(decimal p0, DateTime dateTime)
        {
            Transactions.Add(new Transaction
            {
                Date = dateTime,
                Credit = p0,
                Balance = GetBalance() + p0
            });
        }

        private decimal GetBalance()
        {
            return Transactions.OrderByDescending(t => t.Date).FirstOrDefault()?.Balance ?? 0;
        }

        public Statement GetStatement()
        {
            return new Statement(this.Transactions);
        }

        public void WithDraw(decimal p0, DateTime dateTime)
        {
            Transactions.Add(new Transaction
            {
                Date = dateTime,
                Debit = p0,
                Balance = GetBalance() - p0
            });
        }
    }
}

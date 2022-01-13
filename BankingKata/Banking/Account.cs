using System;
using System.Collections.Generic;

namespace Banking
{
    public class Account
    {
        private List<Transaction> Transactions = new List<Transaction>();

        public void Deposite(decimal p0, DateTime dateTime)
        {
            Transactions.Add(new Transaction
            {
                Date = dateTime, Credit = p0, Balance = p0
            });
        }

        public Statement GetStatement()
        {
            return new Statement(this.Transactions);
        }

        public void WithDraw(int p0, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}

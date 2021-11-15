using System;
using System.Collections.Generic;

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
            _transactions.Add(new Deposit(amount, actionTime));
        }

        public void Withdraw(int amount, DateTime date)
        {
            throw new NotImplementedException();
        }
    }

    public class Deposit : ITransaction
    {
       
        public Deposit(decimal amount, DateTime actionTime)
        {
            Amount = amount;
            Date = actionTime;
        }

        public decimal Amount { get; }

        public DateTime Date { get; }
    }

    public interface ITransaction
    {
        decimal Amount { get; }

        DateTime Date { get; }
    }

}

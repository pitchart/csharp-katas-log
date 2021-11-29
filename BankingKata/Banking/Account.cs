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

            _transactions.Add(new Deposit(amount, actionTime,Balance()));
        }

        private decimal Balance()
        {
            var lastestTansaction = _transactions.LastOrDefault();

            return lastestTansaction?.Balance ?? 0;
        }

        public void Withdraw(int amount, DateTime actionTime)
        {
            _transactions.Add(new WithDraw(amount, actionTime, Balance()));
        }
    }

    public class Deposit : ITransaction
    {
       
        public Deposit(decimal amount, DateTime actionTime, decimal balance)
        {
            Amount = amount;
            Date = actionTime;
            Balance = balance + amount;
        }

        public decimal Amount { get; }

        public DateTime Date { get; }

        public decimal Balance { get; }
    }

    public interface ITransaction
    {
        decimal Amount { get; }

        DateTime Date { get; }
        decimal Balance { get; }
    }

}

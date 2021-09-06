using System;
using System.Collections.Generic;

namespace Banking.Domain
{
    public class Account
    {
        public int Balance { get; private set; }

        public Account()
        {
        }

        public Account(int balance)
        {
            this.Balance = balance;
        }

        private List<ITransaction> Transactions { get; } = new List<ITransaction>();

        public void Deposit(int amount, DateTime date)
        {
            this.Transactions.Add(new Deposit(date, amount));
            this.Balance += amount;
        }

        public void Withdraw(int amount, DateTime parseDate)
        {
            this.Transactions.Add(new Withdrawal(parseDate, -amount));
            this.Balance -= amount;
        }

        public void Transfer(int transferAmount, Account accountB)
        {
            Withdraw(transferAmount, DateTime.Now);
            accountB.Deposit(transferAmount, DateTime.Now);
        }

        public Statement Statement()
        {
            return new Statement(this.Transactions);
        }
    }
}

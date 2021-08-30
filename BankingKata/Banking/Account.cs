using System;
using System.Collections.Generic;

namespace Banking
{
    public class Account
    {
        public int Balance { get; private set; }
        private Statement _statement;

        public Account()
        {
        }

        public Account(int balance)
        {
            Balance = balance;
        }

        private List<ITransaction> Transactions { get; } = new List<ITransaction>();

        public void Deposit(int amount, DateTime date)
        {
            Transactions.Add(new Deposit(date, amount));
            Balance += amount;
        }

        public void Withdraw(int amount, DateTime parseDate)
        {
            Transactions.Add(new Withdrawal(parseDate, -amount));
            Balance -= amount;
        }

        public string PrintStatement()
        {
            _statement = new Statement(Transactions);
            Printer printer = new Printer();
            return printer.Print(_statement);
        }

        public void Transfer(int transferAmount, Account accountB)
        {
            Withdraw(transferAmount, DateTime.Now);
            accountB.Deposit(transferAmount, DateTime.Now);
        }
    }
}

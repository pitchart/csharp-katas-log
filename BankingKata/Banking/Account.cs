using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    public class Account
    {
        public int Balance { get; private set; }
        private Statement _statement;
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
            _statement = new Statement(Transactions.FirstOrDefault());
            return string.Join(Environment.NewLine, _statement.PrepareStatement(Balance));
        }
    }

}

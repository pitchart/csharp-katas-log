using System;

namespace Banking
{
    public class Account
    {
        private const string StatementHeader = "date       ||   credit ||    debit ||  balance";

        public void Deposit(int amount, DateTime date)
        {
            Balance += amount;
        }

        public void Withdraw(int amount, DateTime parseDate)
        {
            Balance -= amount;
        }

        public string PrintStatement()
        {
            return StatementHeader;
        }

        public int Balance { get; private set; }
    }

}

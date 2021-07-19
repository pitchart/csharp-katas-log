using System;

namespace Banking
{

    public class Account
    {
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
            throw new NotImplementedException();
        }

        public int Balance { get; private set; }
    }

}

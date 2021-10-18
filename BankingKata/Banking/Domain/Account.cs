using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Domain
{
    public class Account
    {
        public float Balance { get => Transactions.LastOrDefault()?.Balance ?? 0; }
        
        public Account(float initialDeposit = 0)
        {
            TransactionValidator.ValidateInitialDeposit(initialDeposit);
            this.Status = "Open";

            if (initialDeposit != 0)
            {
                this.Deposit(initialDeposit, DateTime.Now);
            }
        }

        private List<ITransaction> Transactions { get; } = new List<ITransaction>();

        public string Status { get; set; }

        public void Deposit(float amount, DateTime date)
        {
            var transaction = new Deposit(date, amount, Balance);
            this.Transactions.Add(transaction);
        }

        public void Withdraw(float amount, DateTime date)
        {
            var transaction = new Withdrawal(date, amount, Balance);
            this.Transactions.Add(transaction);

            if (Balance < 0)
            {
                this.Status = "Frozen";
            }
        }

        public void Transfer(float transferAmount, Account accountB)
        {
            Withdraw(transferAmount, DateTime.Now);
            accountB.Deposit(transferAmount, DateTime.Now);
        }

        public Statement Statement(IFilter filter = null)
        {
            IList<ITransaction> transactions = this.Transactions;
            if (filter != null)
            {
               transactions =  filter.Filter(this.Transactions);
            }
            return new Statement(transactions);
        }

        public void Close(DateTime dateTime = default)
        {
            if(dateTime == DateTime.MinValue)
                dateTime = DateTime.Now;
            
            this.Status = "Close";
            this.Withdraw(Balance, dateTime);
        }
    }

}

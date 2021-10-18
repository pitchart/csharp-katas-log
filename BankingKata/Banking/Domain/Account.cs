using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Domain
{
    public class Account
    {
        public float Balance
        {
            get => Transactions.LastOrDefault().Value?.Balance ?? 0;
        }
        
        public Account(float initialDeposit = 0)
        {
            TransactionValidator.ValidateInitialDeposit(initialDeposit);
            this.Status = "Open";

            if (initialDeposit != 0)
            {
                this.Deposit(initialDeposit, DateTime.Now);
            }
        }

        private SortedList<DateTime, ITransaction> Transactions { get; } = new SortedList<DateTime, ITransaction>(new DateTimeAscendComparer() );

        public string Status { get; set; }

        public void Deposit(float amount, DateTime date)
        {
            var transaction = new Deposit(date, amount, Balance);
            this.Transactions.Add(date,transaction);
        }

        public void Withdraw(float amount, DateTime date)
        {
            var transaction = new Withdrawal(date, amount, Balance);
            this.Transactions.Add(date, transaction);

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
            IList<ITransaction> transactions = this.Transactions.Values;
            if (filter != null)
            {
               transactions =  filter.Filter(this.Transactions.Values);
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

    internal class DateTimeAscendComparer : IComparer<DateTime>
    {
        public int Compare(DateTime x, DateTime y)
        {
            return DateTime.Compare(x,y);
        }
    }

}

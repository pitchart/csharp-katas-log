﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Domain
{
    public class Account
    {
        public float Balance { get => Transactions.LastOrDefault()?.Balance ?? 0; }
        
        public Account(float initialDeposit = 0)
        {
            if (initialDeposit < 0)
            {
                throw new ArgumentException("Cannot create an account with negative amount");
            }

            if (initialDeposit != 0)
            {
                this.Deposit(initialDeposit, DateTime.Now);
            }
        }

        private List<ITransaction> Transactions { get; } = new List<ITransaction>();

        public void Deposit(float amount, DateTime date)
        {
            var transaction = new Deposit(date, amount, Balance);
            this.Transactions.Add(transaction);
        }

        public void Withdraw(float amount, DateTime date)
        {
            var transaction = new Withdrawal(date, amount, Balance);
            this.Transactions.Add(transaction);
        }

        public void Transfer(float transferAmount, Account accountB)
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
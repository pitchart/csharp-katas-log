using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    public class Account
    {
        private const string StatementHeader = "date       ||   credit ||    debit ||  balance";

        public void Deposit(int amount, DateTime date)
        {
            Transactions.Add(new Transaction(date, amount));
            Balance += amount;
        }

        public void Withdraw(int amount, DateTime parseDate)
        {
            Transactions.Add(new Transaction(parseDate, -amount));
            Balance -= amount;
        }

        public string PrintStatement()
        {
            List<string> lines = new List<string> { StatementHeader };
            Transaction transaction = Transactions.FirstOrDefault();
            if(transaction != null)
            {
                if (float.IsNegative(transaction.v))
                {
                    lines.Add($"{transaction.parseDate.ToString("dd-MM-yyyy")} ||          ||  {(-transaction.v).ToString("0.00").Replace(',', '.')} || {Balance.ToString("0.00").Replace(',', '.')}");
                }else
                {
                    lines.Add($"{transaction.parseDate.ToString("dd-MM-yyyy")} ||  {(transaction.v).ToString("0.00").Replace(',', '.')} ||          ||  {Balance.ToString("0.00").Replace(',', '.')}");
                }
            }
            return string.Join(Environment.NewLine, lines);
        }

        public int Balance { get; private set; }
        private List<Transaction> Transactions { get; } = new List<Transaction>();
    }

    internal class Transaction
    {
        public DateTime parseDate { get; }
        public float v { get; }

        public Transaction(DateTime parseDate, int v)
        {
            this.parseDate = parseDate;
            this.v = v;
        }
    }
}

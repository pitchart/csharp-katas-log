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
            List<string> lines = new List<string> {StatementHeader};
            ITransaction transaction = Transactions.FirstOrDefault();
            if (transaction != null)
            {
                if (transaction is Withdrawal)
                {
                    lines.Add($"{transaction.Date:dd-MM-yyyy} ||          ||  {(-transaction.Value).ToString("0.00").Replace(',', '.')} || {Balance.ToString("0.00").Replace(',', '.')}");
                }
                else
                {
                    lines.Add($"{transaction.Date:dd-MM-yyyy} ||  {(transaction.Value).ToString("0.00").Replace(',', '.')} ||          ||  {Balance.ToString("0.00").Replace(',', '.')}");
                }
            }

            return string.Join(Environment.NewLine, lines);
        }

        public int Balance { get; private set; }
        private List<ITransaction> Transactions { get; } = new List<ITransaction>();
    }

}

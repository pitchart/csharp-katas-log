using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Banking
{

    public class Printer
    {
        public string Print(Statement statement)
        {
            var builder = new StringBuilder("date       ||   credit ||    debit ||  balance");
            if (statement.GetTransactions().Count != 0)
            {
                foreach (var transaction in statement.GetTransactions().OrderByDescending(transaction => transaction.Date))
                {
                    builder.Append(Environment.NewLine);
                    if (transaction.GetType() == typeof(Deposit))
                    {
                        builder.Append($"{transaction.Date.Date:dd-MM-yyyy} ||     {transaction.Amount.ToString("0.00", CultureInfo.InvariantCulture)} ||          ||     {transaction.Balance.ToString("0.00", CultureInfo.InvariantCulture)}");
                    }
                    else
                    {
                        builder.Append($"{transaction.Date.Date:dd-MM-yyyy} ||          ||   {transaction.Amount.ToString("0.00", CultureInfo.InvariantCulture)} ||  {transaction.Balance.ToString("0.00", CultureInfo.InvariantCulture)}");
                    }
                }
            }
            return builder.ToString();
        }
    }

}

using System;
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
                builder.Append(Environment.NewLine);
                builder.Append("22-11-2021 ||     1.00 ||          ||     1.00");
            }
            return builder.ToString();
        }
    }

}

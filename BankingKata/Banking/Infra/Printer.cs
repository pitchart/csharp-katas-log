using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Banking.Domain;

namespace Banking.Infra
{
    public class Printer
    {
        private const string StatementHeader = "date       ||   credit ||    debit ||  balance";

        public IList<string> PrepareStatement(IEnumerable<ITransaction> transactions)
        {
            List<string> lines = new List<string>();
            if (transactions == null || !transactions.Any())
            {
                return lines;
            }

            foreach (ITransaction transaction in transactions)
            {
                if (transaction is Withdrawal)
                {
                    lines.Add($"{transaction.Date:dd-MM-yyyy} ||          || {FormatValue(transaction.Value)} || {FormatValue(transaction.Balance)}");
                }
                else
                {
                    lines.Add($"{transaction.Date:dd-MM-yyyy} || {FormatValue(transaction.Value)} ||          || {FormatValue(transaction.Balance)}");
                }
            }

            return lines;
        }

        private static string FormatValue(float value) => value.ToString("0.00", CultureInfo.InvariantCulture).PadLeft(8);

        public string Print(Statement statement)
        {
            List<string> table = new List<string> { StatementHeader };
            IList<string> lines = PrepareStatement(statement.Transactions);
            table.AddRange(lines);
            return string.Join(Environment.NewLine, table);
        }
    }
}

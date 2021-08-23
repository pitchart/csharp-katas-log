using System;
using System.Collections.Generic;

namespace Banking
{
    class Printer
    {
        private const string StatementHeader = "date       ||   credit ||    debit ||  balance";

        internal string Print(Statement statement, int balance)
        {
            List<string> table = new List<string> { StatementHeader };
            string line = statement.PrepareStatement(balance);
            if (!string.IsNullOrEmpty(line))
            {
                table.Add(line);
            }
            return string.Join(Environment.NewLine, table);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    class Printer
    {
        private const string StatementHeader = "date       ||   credit ||    debit ||  balance";

        internal string Print(Statement statement)
        {
            List<string> table = new List<string> { StatementHeader };
            IList<string> lines = statement.PrepareStatement();
            table.AddRange(lines.Reverse());
            return string.Join(Environment.NewLine, table);
        }
    }
}

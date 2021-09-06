using System;
using System.Collections.Generic;
using System.Linq;
using Banking.Domain;

namespace Banking.Infra
{
    public class Printer
    {
        private const string StatementHeader = "date       ||   credit ||    debit ||  balance";

        public string Print(Statement statement)
        {
            List<string> table = new List<string> { StatementHeader };
            IList<string> lines = statement.PrepareStatement();
            table.AddRange(lines.Reverse());
            return string.Join(Environment.NewLine, table);
        }
    }
}

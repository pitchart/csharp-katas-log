using System.Collections.Generic;
using System.Globalization;

namespace Banking
{
    public class Statement
    {
        private const string StatementHeader = "date       ||   credit ||    debit ||  balance";
        private readonly ITransaction _transaction;

        public Statement(ITransaction transaction)
        {
            _transaction = transaction;
        }

        public IList<string> PrepareStatement(int balance)
        {
            List<string> lines = new List<string> { StatementHeader };
            if (_transaction == null)
            {
                return lines;
            }

            if (_transaction is Withdrawal)
            {
                lines.Add($"{_transaction.Date:dd-MM-yyyy} ||          || {FormatValue(-_transaction.Value)} || {FormatValue(balance)}");
            }
            else
            {
                lines.Add($"{_transaction.Date:dd-MM-yyyy} || {FormatValue(_transaction.Value)} ||          || {FormatValue(balance)}");
            }

            return lines;
        }

        private static string FormatValue(float value) => value.ToString("0.00", CultureInfo.InvariantCulture).PadLeft(8);
    }
}

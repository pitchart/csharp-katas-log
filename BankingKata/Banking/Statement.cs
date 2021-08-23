using System.Collections.Generic;
using System.Globalization;

namespace Banking
{
    public class Statement
    {
        private readonly ITransaction _transaction;

        public Statement(ITransaction transaction)
        {
            _transaction = transaction;
        }

        public string PrepareStatement(int balance)
        {
            if (_transaction == null)
            {
                return null;
            }

            if (_transaction is Withdrawal)
            {
                return $"{_transaction.Date:dd-MM-yyyy} ||          || {FormatValue(-_transaction.Value)} || {FormatValue(balance)}";
            }
            else
            {
                return $"{_transaction.Date:dd-MM-yyyy} || {FormatValue(_transaction.Value)} ||          || {FormatValue(balance)}";
            }
        }

        private static string FormatValue(float value) => value.ToString("0.00", CultureInfo.InvariantCulture).PadLeft(8);
    }
}

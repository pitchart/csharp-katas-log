using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Banking.Domain
{
    public class Statement
    {
        private readonly List<ITransaction> _transactions;

        public Statement(List<ITransaction> transactions)
        {
            _transactions = transactions;
        }

        public IList<string> PrepareStatement()
        {
            List<string> lines = new List<string>();
            float balance = 0;
            if (_transactions == null || !_transactions.Any())
            {
                return lines;
            }
            
            foreach (ITransaction transaction in _transactions)
            {
                balance += transaction.Value;
                if (transaction is Withdrawal)
                {
                    lines.Add($"{transaction.Date:dd-MM-yyyy} ||          || {FormatValue(-transaction.Value)} || {FormatValue(balance)}");
                }
                else
                {
                    lines.Add($"{transaction.Date:dd-MM-yyyy} || {FormatValue(transaction.Value)} ||          || {FormatValue(balance)}");
                }
            }

            return lines;
        }

        private static string FormatValue(float value) => value.ToString("0.00", CultureInfo.InvariantCulture).PadLeft(8);
    }
}

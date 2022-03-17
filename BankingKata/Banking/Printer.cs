using System;
using System.Globalization;
using System.Linq;

namespace Banking
{
    public class Printer
    {
        private const string separator = " || ";

        public static string PrintAccountBankStatement(Statement statement)
        {
            string header = "date       ||";
            if (statement.Transactions.Where(transaction => transaction is Deposite).Any())
            {
                header = header + "   credit" + separator;
            }
            if (statement.Transactions.Where(transaction => transaction is Withdrawal).Any())
            {
                header = header + "   debit" + separator;
            }

            var result = header + " balance";

            foreach (var transaction in statement.Transactions.OrderByDescending(t => t.Date))
            {
                if (transaction is Withdrawal)
                    result += Environment.NewLine + FormatDate(transaction.Date) + separator + FormatCell("") + separator + FormatCell(FormatAmount(transaction.Amount)) + separator +
                              FormatCell(FormatAmount(transaction.Balance));
                else
                    result += Environment.NewLine + FormatDate(transaction.Date) + separator + FormatCell(FormatAmount(transaction.Amount)) + separator + FormatCell("") + separator +
                          FormatCell(FormatAmount(transaction.Balance));
            }

            return result;
        }

        private static string FormatCell(string v)
        {
            return v.PadLeft(8);
        }

        private static string FormatAmount(decimal price)
        {
            return price.ToString("0.00", CultureInfo.InvariantCulture);
        }

        private static string FormatDate(DateTime date)
        {
            return date.ToString("dd-MM-yyyy");
        }
    }
}

using System;
using System.Globalization;

namespace Banking
{
    public class Printer
    {
        public static string PrintAccountBankStatement(Statement statement)
        {
            var result = "date       ||   credit ||    debit ||  balance";
            foreach (var transaction in statement.Transactions)
            {
                result += Environment.NewLine + FormatDate(transaction.Date) + " ||  " + FormatPrice(transaction.Credit) + " ||          ||  " +
                          FormatPrice(transaction.Balance);
            }

            return result;
        }

        private static string FormatPrice(decimal price)
        {
            return price.ToString("0.00", CultureInfo.InvariantCulture);
        }

        private static string FormatDate(DateTime date)
        {
            return date.ToString("dd-MM-yyyy");
        }
    }
}

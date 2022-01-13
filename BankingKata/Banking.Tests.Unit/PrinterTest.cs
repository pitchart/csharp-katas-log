using System;
using Xunit;

namespace Banking.Tests.Unit
{

    public class PrinterTest
    {
        [Fact]
        public void ShouldPrintHeaderWhenNoTransactionOnAccount()
        {
            var account = new Account();
            var statement = account.GetStatement();
            var printedBankStatement = Printer.PrintAccountBankStatement(statement);
            string header = "date       ||   credit ||    debit ||  balance";
            Assert.Equal(header, printedBankStatement);
        }
        [Fact]
        public void ShouldPrintDeposite()
        {
            var account = new Account();
            account.Deposite(1000, new DateTime(2012,1,10));
            var statement = account.GetStatement();
            var printedBankStatement = Printer.PrintAccountBankStatement(statement);
            string header = "date       ||   credit ||    debit ||  balance" + Environment.NewLine 
                + "10-01-2012 ||  1000.00 ||          ||  1000.00";
            Assert.Equal(header, printedBankStatement);
        }
    }

}

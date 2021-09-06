using System;
using Banking.Domain;
using Banking.Infra;
using Xunit;

namespace Banking.Tests.Unit
{

    public class PrinterTests
    {
        private Printer _printer;

        public PrinterTests()
        {
            _printer = new Printer();
        }

        [Fact]
        public void Should_print_header_when_no_transaction()
        {
            //Arrange
            Account account = new Account();
            Statement statement =  account.Statement();

            //Act
            string printStatement = _printer.Print(statement);

            //Assert
            Assert.Equal("date       ||   credit ||    debit ||  balance", printStatement);
        }

        [Fact]
        public void Should_print_statement_when_withdrawing()
        {
            //Arrange
            Account account = new Account();
            account.Withdraw(5000, new DateTime(2012, 1, 13));
            Statement statement = account.Statement();

            //Act

            string printStatement = _printer.Print(statement);

            //Assert
            var expected = "date       ||   credit ||    debit ||  balance" + Environment.NewLine +
                           "13-01-2012 ||          ||  5000.00 || -5000.00";
            Assert.Equal(expected, printStatement);
        }

        [Fact]
        public void Should_print_statement_when_deposit()
        {
            //Arrange
            Account account = new Account();
            account.Deposit(5000, new DateTime(2012, 1, 13));
            Statement statement = account.Statement();

            //Act
            string printStatement = _printer.Print(statement);

            //Assert
            var expected = "date       ||   credit ||    debit ||  balance" + Environment.NewLine +
                           "13-01-2012 ||  5000.00 ||          ||  5000.00";
            Assert.Equal(expected, printStatement);
        }

        [Fact]
        public void Should_print_statement_when_deposit_is_500()
        {
            //Arrange
            Account account = new Account();
            account.Deposit(500, new DateTime(2012, 1, 13));
            Statement statement = account.Statement();

            //Act
            string printStatement = _printer.Print(statement);

            //Assert
            string expected = "date       ||   credit ||    debit ||  balance" + Environment.NewLine +
                              "13-01-2012 ||   500.00 ||          ||   500.00";
            Assert.Equal(expected, printStatement);
        }

        [Fact]
        public void Should_print_statement_when_multi_transactions()
        {
            //Arrange
            Account account = new Account();
            account.Deposit(500, new DateTime(2012, 1, 13));
            account.Withdraw(300, new DateTime(2012, 1, 14));
            Statement statement = account.Statement();

            //Act
            string printStatement = _printer.Print(statement);

            //Assert
            string expected = "date       ||   credit ||    debit ||  balance" + Environment.NewLine +
                              "14-01-2012 ||          ||   300.00 ||   200.00" + Environment.NewLine +
                              "13-01-2012 ||   500.00 ||          ||   500.00";
            Assert.Equal(expected, printStatement);
        }
    }

}

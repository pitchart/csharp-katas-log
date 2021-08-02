using System;
using Xunit;

namespace Banking.Tests.Unit
{

    public class BankingTest
    {
        [Fact]
        public void Should_increment_account_when_deposing()
        {
            //Arrange
            Account account = new Account();
            int amount = 5000;
            
            //Act
            account.Deposit(amount, DateTime.Today);
            
            //Assert
            Assert.Equal(amount,account.Balance);
        }

        [Fact]
        public void Should_increment_account_when_deposing_twice()
        {
            //Arrange
            Account account = new Account();

            //Act
            account.Deposit(5000, DateTime.Today);
            account.Deposit(6000, DateTime.Today);

            //Assert
            Assert.Equal(11000, account.Balance);
        }

        [Fact]
        public void Should_decrement_account_when_withdrawing()
        {
            //Arrange
            Account account = new Account();
            int amount = 5000;

            //Act
            account.Withdraw(amount, DateTime.Today);

            //Assert
            Assert.Equal(-amount, account.Balance);
        }

        [Fact]
        public void Should_decrement_account_when_withdrawing_twice()
        {
            //Arrange
            Account account = new Account();

            //Act
            account.Withdraw(5000, DateTime.Today);
            account.Withdraw(6000, DateTime.Today);

            //Assert
            Assert.Equal(-11000, account.Balance);
        }

        [Fact]
        public void Should_sum_transactions_when_withdrawing_and_deposing()
        {
            //Arrange
            Account account = new Account();

            //Act
            account.Deposit(6000, DateTime.Today);
            account.Withdraw(5000, DateTime.Today);

            //Assert
            Assert.Equal(1000, account.Balance);
        }

        [Fact]
        public void Should_print_header_when_no_transaction()
        {
            //Arrange
            Account account = new Account();

            //Act
            string printStatement = account.PrintStatement();

            //Assert
            Assert.Equal("date       ||   credit ||    debit ||  balance", printStatement);
        }

        [Fact]
        public void Should_print_statement_when_withdrawing()
        {
            //Arrange
            Account account = new Account();

            //Act
            account.Withdraw(5000, new DateTime(2012, 1, 13));

            string printStatement = account.PrintStatement();

            //Assert
            var expected = "date       ||   credit ||    debit ||  balance" + Environment.NewLine + "13-01-2012 ||          ||  5000.00 || -5000.00";
            Assert.Equal(expected, printStatement);
        }

        [Fact]
        public void Should_print_statement_when_deposit()
        {
            //Arrange
            Account account = new Account();

            //Act
            account.Deposit(5000, new DateTime(2012, 1, 13));

            string printStatement = account.PrintStatement();

            //Assert
            var expected = "date       ||   credit ||    debit ||  balance" + Environment.NewLine + "13-01-2012 ||  5000.00 ||          ||  5000.00";
            Assert.Equal(expected, printStatement);
        }

    }

}

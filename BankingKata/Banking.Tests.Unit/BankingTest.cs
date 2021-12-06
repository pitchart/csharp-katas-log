using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Banking.Tests.Unit
{

    public class BankingTest
    {
        [Fact]
        public void Should_only_contain_headers_when_printing_an_empty_account()
        {
            // Arrange
            var account = new Account();
            var printer = new Printer();

            // Act
            string output = printer.Print(account.GetStatement());

            // Assert
            var ExpectedOutput = "date       ||   credit ||    debit ||  balance";
            output.Should().Be(ExpectedOutput);
        }


        [Theory]
        [InlineData(1, "2021-11-22", "22-11-2021 ||     1.00 ||          ||     1.00")]
        [InlineData(2, "2021-11-22", "22-11-2021 ||     2.00 ||          ||     2.00")]
        public void Should_print_deposits(int amount, string date, string transactionLine)
        {
            //Arrange
            var account = new Account();
            account.Deposit(amount, DateTime.Parse(date));
            var printer = new Printer();

            //Act
            string output = printer.Print(account.GetStatement());

            //Assert
            var ExpectedOutput = transactionLine;
            output.Split(Environment.NewLine).Last().Should().Be(ExpectedOutput);
        }

        [Fact]
        public void Should_print_multiple_deposits_order_by_date_desc()
        {
            //Arrange

            var account = new Account();
            account.Deposit(100, DateTime.Parse("2021-11-21"));
            account.Withdraw(200, DateTime.Parse("2021-11-22"));

            var printer = new Printer();

            //Act
            string output = printer.Print(account.GetStatement());

            //Assert
            var ExpectedOutputDate = "21-11-2021";
            output.Split(Environment.NewLine).Last().Should().Contain(ExpectedOutputDate);
        }


        [Theory]
        [InlineData(500, "2021-11-22", "22-11-2021 ||          ||   500.00 ||  1000.00")]
        public void Should_print_withdrawal(int amount, string date, string transactionLine)
        {
            //Arrange
            var account = new Account();
            account.Deposit(1500, DateTime.Parse("2021-11-21"));
            account.Withdraw(amount, DateTime.Parse(date));
            var printer = new Printer();

            //Act
            string output = printer.Print(account.GetStatement());

            //Assert
            var ExpectedOutput = transactionLine;
            string s = output.Split(Environment.NewLine)[1];
            s.Should().Be(ExpectedOutput);
        }

        //[Fact]
        //public void Should_print_transactions()
        //{
        //    //Arrange

        //    var account = new Account();
        //    account.Deposit(300, DateTime.Parse("2021-11-21"));
        //    account.Withdraw(100, DateTime.Parse("2021-11-22"));

        //    var printer = new Printer();

        //    //Act
        //    string output = printer.Print(account.GetStatement());

        //    //Assert
        //    var ExpectedOutput =
        //        "22-11-2021 ||     100.00 ||          ||     200.00" + Environment.NewLine +
        //        "21-11-2021 ||     300.00 ||          ||     300.00";
        //    output.Split(Environment.NewLine).Last().Should().Be(ExpectedOutput);
        //}
    }
}

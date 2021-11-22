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
    }
}

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Banking.Tests.Unit
{

    public class AccountTests
    {
        [Fact]
        public void Should_be_able_to_deposit()
        {
            // Arrange
            Account account = new Account();

            // Act
            account.Deposit(1, DateTime.Parse("2021-11-15 00:00:00"));

            // Assert
            var statement = account.GetStatement();
            var transaction = statement.GetTransactions().First();
            transaction.Amount.Should().Be(1);
            transaction.Date.Should().Be(DateTime.Parse("2021-11-15 00:00:00"));
            transaction.Should().BeOfType(typeof(Deposit));
        }
    }

}

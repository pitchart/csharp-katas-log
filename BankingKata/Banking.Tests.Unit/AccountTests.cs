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
            account.Deposit(new Amount(1m), DateTime.Parse("2021-11-15 00:00:00"));

            // Assert
            Statement statement = account.GetStatement();
            ITransaction transaction = statement.GetTransactions().First();
            transaction.Amount.Value.Should().Be(1m);
            transaction.Date.Should().Be(DateTime.Parse("2021-11-15 00:00:00"));
            transaction.Should().BeOfType(typeof(Deposit));
        }

        [Fact]
        public void Should_be_able_to_withdraw()
        {
            //Arrange
            Account account = new Account();
            account.Deposit(new Amount(2m), DateTime.Parse("2021-11-14 00:00:00"));

            //Act
            account.Withdraw(new Amount(1m), DateTime.Parse("2021-11-15 00:00:00"));

            //Assert
            ITransaction transaction = account.GetStatement().GetTransactions().First();
            transaction.Amount.Value.Should().Be(1m);
            transaction.Date.Should().Be(DateTime.Parse("2021-11-15 00:00:00"));
            transaction.Should().BeOfType(typeof(WithDraw));
        }

        [Fact]
        public void Should_be_able_to_deposits_and_withdraw()
        {
            // Arrange
            Account account = new Account();

            // Act
            account.Deposit(new Amount(1000m), DateTime.Parse("2021-11-15 00:00:00"));
            account.Withdraw(new Amount(100m), DateTime.Parse("2021-11-16 00:00:00"));
            account.Deposit(new Amount(500m), DateTime.Parse("2021-11-17 00:00:00"));


            // Assert
            Statement statement = account.GetStatement();
            ITransaction transaction = statement.GetTransactions().First();
            transaction.Balance.Value.Should().Be(1400m);
            transaction.Date.Should().Be(DateTime.Parse("2021-11-17 00:00:00"));
        }
    }

}

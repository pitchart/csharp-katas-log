using System;
using Banking.Domain;
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
            Assert.Equal(amount, account.Balance);
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
        public void Should_decrease_clientA_balance_when_makes_transfer_to_clientB()
        {
            //Arrange
            const int initialBalanceA = 1000;
            const int initialBalanceB = 100;
            const int amountToTransfer = 500;
            Account accountA = new Account(initialBalanceA);
            Account accountB = new Account(initialBalanceB);

            //Act
            accountA.Transfer(amountToTransfer, accountB);

            //Assert

            Assert.Equal(initialBalanceA - amountToTransfer, accountA.Balance);
            Assert.Equal(initialBalanceB + amountToTransfer, accountB.Balance);
        }
    }
}

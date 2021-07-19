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
    }

}

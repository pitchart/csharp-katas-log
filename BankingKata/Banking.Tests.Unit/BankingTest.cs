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
    }

}

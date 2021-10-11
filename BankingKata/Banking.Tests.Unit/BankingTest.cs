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

        [Fact]
        public void Should_not_create_account_with_debt()
        {
            var exception = Assert.Throws<InvalidAmountException>(() => new Account(-100));
            Assert.Equal("Cannot create an account with negative amount",exception.Message);
        }

        [Fact]
        public void Should_not_withdraw_negative_amount()
        {
            Account account = new Account(100);

            var exception = Assert.Throws<InvalidAmountException>(() => account.Withdraw(-10, DateTime.Now));
            Assert.Equal("Cannot withdraw with negative amount",exception.Message);
        }

        [Fact]
        public void Should_not_deposit_negative_amount()
        {
            Account account = new Account(100);

            var exception = Assert.Throws<InvalidAmountException>(() => account.Deposit(-10, DateTime.Now));
            Assert.Equal("Cannot deposit with negative amount", exception.Message);
        }

        [Fact]
        public void Should_filter_withdrawal_transactions_when_deposit_filter_is_set()
        {
            //Arrange
            Account account = new Account(100);
            account.Withdraw(50, DateTime.Now);
            IFilter filter = new DepositFilter();

            //Act
            Statement statement = account.Statement(filter);

            //Assert
            Assert.Single(statement.Transactions);
            Assert.Collection(statement.Transactions, tr => Assert.True(tr is Deposit));
        }
        
        [Fact]
        public void Should_filter_withdrawal_transactions_when_deposit_filter_is_set_with_no_deposit()
        {
            //Arrange
            Account account = new Account();
            account.Withdraw(50, DateTime.Now);
            IFilter filter = new DepositFilter();

            //Act
            Statement statement = account.Statement(filter);

            //Assert
            Assert.Empty(statement.Transactions);
        }
        
        [Fact]
        public void Should_filter_deposit_transactions_when_withdrawal_filter_is_set()
        {
            //Arrange
            Account account = new Account(100);
            account.Withdraw(50, DateTime.Now);
            IFilter filter = new WithdrawalFilter(); 

            //Act
            Statement statement = account.Statement(filter);

            //Assert
            Assert.Single(statement.Transactions);
            Assert.Collection(statement.Transactions, tr => Assert.True(tr is Withdrawal));
        }
        
        [Fact]
        public void Should_filter_deposit_transactions_when_withdrawal_filter_is_set_with_no_withdrawal()
        {
            //Arrange
            Account account = new Account(100);
            IFilter filter = new WithdrawalFilter(); 

            //Act
            Statement statement = account.Statement(filter);

            //Assert
            Assert.Empty(statement.Transactions);
        }
    }
}

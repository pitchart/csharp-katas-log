using FluentAssertions;
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
    }
}

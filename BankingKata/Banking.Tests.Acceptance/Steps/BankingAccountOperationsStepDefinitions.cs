using System;
using System.Globalization;
using TechTalk.SpecFlow;
using Xunit;

namespace Banking.Tests.Acceptance.Steps
{

    [Binding]
    public sealed class BankingAccountOperationsStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly Account _account = new Account();

        private string _printStatementResult;

        public BankingAccountOperationsStepDefinitions()
        {
        }

        [Given(@"a client makes a deposit of (.*) on (.*)")]
        [Given(@"a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(int amount, string date)
        {
            DateTime parseDate = ParseDate(date);

            _account.Deposit(amount, parseDate);
        }

        [When(@"she prints her bank statement")]
        public void WhenShePrintsHerBankStatement()
        {
            _printStatementResult = _account.PrintStatement();
        }

        [Then(@"she would see")]
        public void ThenSheWouldSee(string multilineText)
        {
            Assert.Equal(multilineText, _printStatementResult);
        }

        [Given(@"a withdrawal of (.*) on (.*)")]
        public void GivenAWithdrawalOfOn(int amount, string date)
        {
            DateTime parseDate = ParseDate(date);
            _account.Withdraw(amount, parseDate);
        }

        private static DateTime ParseDate(string date)
        {
            DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out DateTime parseDate);
            return parseDate;
        }
    }
}

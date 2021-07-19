using System;
using TechTalk.SpecFlow;
using Xunit;

namespace Banking.Tests.Acceptance.Steps
{

    [Binding]
    public sealed class BankingAccountOperationsStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        private Account _account = new Account();

        private string _printStatementResult;

        public BankingAccountOperationsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a client makes a deposit of (.*) on (.*)")]
        [Given(@"a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(int amount, string date)
        {
            DateTime parseDate = ParseDate(date);

            _account.Deposit(amount, parseDate);

            ScenarioContext.StepIsPending();
        }

        [When(@"she prints her bank statement")]
        public void WhenShePrintsHerBankStatement()
        {
            _printStatementResult = _account.PrintStatement();
            ScenarioContext.StepIsPending();
        }

        [Then(@"she would see")]
        public void ThenSheWouldSee(string multilineText)
        {
            Assert.Equal(multilineText, _printStatementResult);
            ScenarioContext.StepIsPending();
        }

        [Given(@"a withdrawal of (.*) on (.*)")]
        public void GivenAWithdrawalOfOn(int amount, string date)
        {
            DateTime parseDate = ParseDate(date);
            _account.Withdraw(amount, parseDate);
            ScenarioContext.StepIsPending();
        }

        private static DateTime ParseDate(string date)
        {
            DateTime.TryParse(date, out DateTime parseDate);
            return parseDate;
        }
    }
}

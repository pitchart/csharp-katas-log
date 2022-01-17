using System;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Banking.Tests.Acceptance.Steps
{

    [Binding]
    public sealed class BankingAccountOperationsStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        private Account _clientAccount = new Account();

        private Printer _printer = new Printer();

        private string _printedStatement;

        public BankingAccountOperationsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a client makes a deposit of (.*) on (.*)")]
        [Given(@"a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(int amount, DateTime actionTime)
        {
            _clientAccount.Deposit(new Amount(amount), actionTime);
        }

        [When(@"she prints her bank statement")]
        public void WhenShePrintsHerBankStatement()
        {
            _printedStatement = _printer.Print(_clientAccount.GetStatement());
        }

        [Then(@"she would see")]
        public void ThenSheWouldSee(string multilineText)
        {
            _printedStatement.Should().Be(multilineText);
        }

        [Given(@"a withdrawal of (.*) on (.*)")]
        public void GivenAWithdrawalOfOn(int amount, DateTime date)
        {
            _clientAccount.Withdraw(new Amount(amount), date);
        }
    }

}

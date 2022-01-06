using System;
using TechTalk.SpecFlow;
using Xunit;
using Banking;

namespace Banking.Tests.Acceptance.Steps
{

    [Binding]
    public sealed class BankingAccountOperationsStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly Account _account = new Account();
        private string printedBankStatement = string.Empty;
        public BankingAccountOperationsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a client makes a deposit of (.*) on (.*)")]
        [Given(@"a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(int p0, string p1)
        {
            _account.Deposite(p0, Convert.ToDateTime(p1));
        }

        [When(@"she prints her bank statement")]
        public void WhenShePrintsHerBankStatement()
        {
            var statement = _account.GetStatement();
            printedBankStatement = Printer.PrintAccountBankStatement(statement);
        }

        [Then(@"she would see")]
        public void ThenSheWouldSee(string multilineText)
        {
            Assert.Equal(multilineText, printedBankStatement);
        }

        [Given(@"a withdrawal of (.*) on (.*)")]
        public void GivenAWithdrawalOfOn(int p0, string p1)
        {
            _account.WithDraw(p0, Convert.ToDateTime(p1));
        }
    }
}

using System;
using TechTalk.SpecFlow;
using Xunit;
using Banking;
using System.Globalization;

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

        [StepArgumentTransformation(@"(\d{2}-\d{2}-\d{4})")]
        public DateTime InXDaysTransform(string date)
        {
            return DateTime.ParseExact(date, "dd-mm-yyyy", CultureInfo.CurrentCulture);
        }

        [Given(@"a client makes a deposit of (.*) on (.*)")]
        [Given(@"a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(decimal p0, DateTime p1)
        {
            _account.Deposite(p0,  p1);
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
        public void GivenAWithdrawalOfOn(decimal p0, DateTime p1)
        {
            _account.WithDraw(p0, p1);
        }
    }
}

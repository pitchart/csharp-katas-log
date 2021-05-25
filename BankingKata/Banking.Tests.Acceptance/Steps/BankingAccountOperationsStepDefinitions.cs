using System;
using TechTalk.SpecFlow;

namespace Banking.Tests.Acceptance.Steps
{

    [Binding]
    public sealed class BankingAccountOperationsStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public BankingAccountOperationsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a client makes a deposit of (.*) on (.*)")]
        [Given(@"a deposit of (.*) on (.*)")]
        public void GivenAClientMakesADepositOfOn(int p0, DateTime p1)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"she prints her bank statement")]
        public void WhenShePrintsHerBankStatement()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"she would see")]
        public void ThenSheWouldSee(string multilineText)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"a withdrawal of (.*) on (.*)")]
        public void GivenAWithdrawalOfOn(int p0, string p1)
        {
            ScenarioContext.StepIsPending();
        }
    }
}

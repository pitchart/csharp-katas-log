using System;
using System.Globalization;
using Banking.Domain;
using Banking.Infra;
using TechTalk.SpecFlow;
using Xunit;

namespace Banking.Tests.Acceptance.Steps
{

    [Binding]
    public sealed class BankingAccountOperationsStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private Account _account = new Account();
        private Account _accountB = new Account();
        private readonly Printer _printer = new Printer();

        private IFilter _filter = null ;

        private string _printStatementResult;

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
            _printStatementResult = _printer.Print( _account.Statement(_filter));
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

        [Given(@"clientA has a balance of (.*)")]
        public void GivenClientAHasABalanceOf(int balance)
        {
            _account = new Account(balance);
        }

        [Given(@"clientB has a balance of (.*)")]
        public void GivenClientBHasABalanceOf(int balance)
        {
            _accountB = new Account(balance);
        }

        [When(@"clientA transfer (.*) to clientB")]
        public void WhenClientATransferToClientB(int transferAmount)
        {
            _account.Transfer(transferAmount, _accountB);
        }

        [When(@"she filters by deposit")]
        public void WhenSheChooseToFilterByDeposit()
        {
            _filter = new DepositFilter();
        }

        [When(@"she filters by withdrawal")]
        public void WhenSheFiltersByWithdrawal()
        {
            _filter = new WithdrawalFilter();
        }

        [Then(@"clientA balance should be (.*) and clientB balance should be (.*)")]
        public void ThenClientABalanceShouldBeAndClientBBalanceShouldBe(int balanceA, int balanceB)
        {
            Assert.Equal(balanceA, _account.Balance);
            Assert.Equal(balanceB, _accountB.Balance);
        }
        
        private static DateTime ParseDate(string date)
        {
            DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out DateTime parseDate);
            return parseDate;
        }
    }

}

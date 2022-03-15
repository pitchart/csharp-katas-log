using FluentAssertions;
using Tcrkata.Acceptance.Tests.Drivers;

namespace Tcrkata.Acceptance.Tests.Steps;

[Binding]
public class SubmarineSteps
{
    private readonly SubmarineDriver driver;

    public SubmarineSteps(SubmarineDriver driver)
    {
        this.driver = driver;
    }

    [Given(@"submarine is initialized")]
    public void SubmarineInitialization() => this.driver.InitializeSubmarine();

    [Then(@"submarine depth should be (.*)")]
    public void VerifySubmarineDepth(int depth) => this.driver.GetSubmarineDepth().Should().Be(depth);

    [Then(@"submarine position should be (.*)")]
    public void VerifySubmarinePosition(int position) => this.driver.GetSubmarinePosition().Should().Be(position);

    [Then(@"submarine aim should be (.*)")]
    public void VerifySubmarineAim(int aim) => this.driver.GetSubmarineAim().Should().Be(aim);

    [Then(@"submarine final value should be (.*)")]
    public void VerifySubmarineFinalValue(int finalValue) => this.driver.GetFinalValue().Should().Be(finalValue);

    [Given(@"submarine receives command (.*)")]
    [When(@"submarine receives command (.*)")]
    public void SendCommand(string command) => this.driver.SendCommand(command);

    [When(@"submarine receives all commands from file (.*)")]
    public void SendCommands(string filename)
    {
        IEnumerable<string> lines = File.ReadLines(string.Concat(Directory.GetCurrentDirectory(), filename));
        lines.ToList().ForEach(this.driver.SendCommand);
    }

    [Then(@"submarine final value should match value from file (.*)")]
    public void VerifySubmarineFinalValueFromFile(string filename)
    {
        string finalValue = File.ReadLines(string.Concat(Directory.GetCurrentDirectory(), filename)).First();
        this.driver.GetFinalValue().Should().Be(int.Parse(finalValue));
    }
}
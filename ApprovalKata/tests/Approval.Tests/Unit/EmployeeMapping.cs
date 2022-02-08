using FluentAssertions;
using Xunit;

namespace Approval.Tests.Unit;

public class EmployeeMapping
{
    [Fact(DisplayName = "Here we should check the mapping from ReadModels.Employee -> EmployeeEntity")]
    public void Should_Map_Employee_To_EmployeeEntity()
        => true.Should().BeFalse();
}

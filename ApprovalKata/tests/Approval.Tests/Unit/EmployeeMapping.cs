using Approval.Shared.Data;
using Approval.Shared.ReadModels;
using FluentAssertions;
using System;
using Xunit;

namespace Approval.Tests.Unit;

public class EmployeeMapping
{
    [Fact(DisplayName = "Here we should check the mapping from ReadModels.Employee -> EmployeeEntity")]
    public void Should_Map_Employee_To_EmployeeEntity()
    {
        //Arrange
        Employee employee = new(1, "mohammed", "sajid", "mohammed.sajid@cdbdx.biz", new DateTime(1988, 4, 30),
            1, "dep");

        //Act
        EmployeeEntity employeeEntity = Map<EmployeeEntity>(employee);

        //Assert
        employeeEntity.Should().NotBeNull();
        employeeEntity.Id.Should().Be(employee.EmployeeId);
        employeeEntity.FirstName.Should().Be(employee.FirstName);
        employeeEntity.LastName.Should().Be(employee.LastName);
        employeeEntity.Email.Should().Be(employee.Email);
        employeeEntity.DateOfBirth.ToDateTime(TimeOnly.MinValue).Should().Be(employee.DateOfBirth.Date);
        employeeEntity.DepartmentId.Should().Be(employee.DepartmentId);
        employeeEntity.Department.Should().Be(employee.Department);
    }

    private T Map<T>(Employee employee)
    {
        throw new NotImplementedException();
    }
}

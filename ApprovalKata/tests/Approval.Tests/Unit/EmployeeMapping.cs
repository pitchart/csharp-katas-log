using System;
using System.Threading.Tasks;
using Approval.Shared.Data;
using Approval.Shared.ReadModels;
using Approval.Web;
using AutoMapper;
using FluentAssertions;
using VerifyXunit;
using Xunit;
using static VerifyXunit.Verifier;


namespace Approval.Tests.Unit;

[UsesVerify]
public class EmployeeMapping
{
    private IMapper _mapper;

    public EmployeeMapping()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        _mapper = config.CreateMapper();
    }

    [Fact(DisplayName = "Here we should check the mapping from ReadModels.Employee -> EmployeeEntity")]
    public void Should_Map_Employee_To_EmployeeEntity()
    {
        //Arrange
        Employee employee = new Employee(1, "employeeFirstName", "employeeLastName", "employee@employee.com",
            new DateTime(2000, 1, 10), 1, "department");

        //Act
        EmployeeEntity employeeEntity = Map(employee);

        employeeEntity.Should().NotBeNull();
        employeeEntity.Id.Should().Be(employee.EmployeeId);
        employeeEntity.FirstName.Should().Be(employee.FirstName);
        employeeEntity.LastName.Should().Be(employee.LastName);
        employeeEntity.Email.Should().Be(employee.Email);
        employeeEntity.DateOfBirth.Should().Be(DateOnly.FromDateTime(employee.DateOfBirth));
        employeeEntity.DepartmentId.Should().Be(employee.DepartmentId);
        employeeEntity.Department.Should().Be(employee.Department);
    }

    [Fact(DisplayName = "Here we should check the mapping from ReadModels.Employee -> EmployeeEntity")]
    public Task Should_Map_Employee_To_EmployeeEntity_WithVerify()
    {
        //Arrange
        Employee employee = new Employee(1, "employeeFirstName", "employeeLastName", "employee@employee.com",
            new DateTime(2000, 1, 10), 1, "department");

        //Act
        EmployeeEntity employeeEntity = Map(employee);

        return Verify(employeeEntity);
    }

    private EmployeeEntity Map(Employee employee)
    {
        return _mapper.Map<EmployeeEntity>(employee);

    }
}

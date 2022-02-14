using Approval.Shared.Data;
using Approval.Shared.ReadModels;
using FluentAssertions;
using System;
using Approval.Web;
using AutoMapper;
using Xunit;

namespace Approval.Tests.Unit;

public class EmployeeMapping
{
    private IMapper _mapper;
    public EmployeeMapping()
    {
        var config = new MapperConfiguration(cfg => {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact(DisplayName = "Here we should check the mapping from ReadModels.Employee -> EmployeeEntity")]
    public void Should_Map_Employee_To_EmployeeEntity()
    {
        //Arrange
        Employee employee = new(1, "mohammed", "sajid", "mohammed.sajid@cdbdx.biz", new DateTime(1988, 4, 30),
            1, "dep");

        //Act
        EmployeeEntity employeeEntity = Map(employee);

        //Assert
        employeeEntity.Should().NotBeNull();
        employeeEntity.Id.Should().Be(employee.EmployeeId);
        employeeEntity.FirstName.Should().Be(employee.FirstName);
        employeeEntity.LastName.Should().Be(employee.LastName);
        employeeEntity.Email.Should().Be(employee.Email);
        employeeEntity.DateOfBirth.Should().Be(DateOnly.FromDateTime(employee.DateOfBirth));
        employeeEntity.DepartmentId.Should().Be(employee.DepartmentId);
        employeeEntity.Department.Should().Be(employee.Department);
    }

    [Fact(DisplayName = "Here we should check the mapping from SalesForce.PersonAccount -> IndividualParty")]
    public void Should_Map_PersonAccount_To_IndividualParty()
    {
        throw new NotImplementedException();
    }

    private EmployeeEntity Map(Employee employee)
    {
        return _mapper.Map<EmployeeEntity>(employee);
    }
}

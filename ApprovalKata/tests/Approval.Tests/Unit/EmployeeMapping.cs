using Approval.Shared.Data;
using Approval.Shared.ReadModels;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Approval.Shared.SalesForce;
using Approval.Web;
using AutoMapper;
using FluentAssertions.Extensions;
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
        PersonAccount personAccount = DataBuilder.AlCapone();

        IndividualParty individualParty = Map(personAccount);

        individualParty.BirthCity.Should().Be(personAccount.CityOfBirth__pc);
        individualParty.BirthDate.Should().Be(25.January(1899));
        individualParty.FirstName.Should().Be(personAccount.FirstName);
        individualParty.LastName.Should().Be(personAccount.LastName);
        individualParty.MiddleName.Should().Be(personAccount.MiddleName);
        individualParty.PepMep.Should().Be(false);
        individualParty.Title.Should().Be(personAccount.Salutation);
        individualParty.Documents.First().DocumentType.Should().Be(personAccount.LegalDocumentName1__c);
        individualParty.Documents.First().ExpirationDate.Should().Be(5.January(2000));
        individualParty.Documents.First().Number.Should().Be(personAccount.LegalDocumentNumber1__c);
        individualParty.Gender.Should().Be(Gender.Male);
    }

    [Fact(DisplayName = "Here we should check the mapping from SalesForce.PersonAccount -> IndividualParty")]
    public Task Should_Map_PersonAccount_To_IndividualParty_WithVerify()
    {
        PersonAccount personAccount = DataBuilder.AlCapone();

        IndividualParty individualParty = Map(personAccount);

        return Verify(individualParty).ModifySerialization(opt => opt.DontScrubDateTimes());
    }

    private EmployeeEntity Map(Employee employee)
    {
        return _mapper.Map<EmployeeEntity>(employee);
    }

    private IndividualParty Map(PersonAccount personAccount)
    {
        return _mapper.Map<IndividualParty>(personAccount);
    }
}

using Approval.Shared.Data;
using Approval.Shared.ReadModels;
using Approval.Web;
using AutoMapper;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;
using static VerifyXunit.Verifier;

namespace Approval.Tests.Unit;

[UsesVerify]
public class EmployeeMapping
{
    private readonly IMapper _mapper;
  
    public EmployeeMapping()
    {
        var config = new MapperConfiguration(cfg => { cfg.AddProfile<MapperProfile>(); });
        _mapper = config.CreateMapper();
    }

    [Fact(DisplayName = "Here we should check the mapping from ReadModels.Employee -> EmployeeEntity")]
    public Task Should_Map_Employee_To_EmployeeEntity()
    {
        Employee e = new Employee(EmployeeId : 1,FirstName : "Michon", LastName : "Louis", Email :"michonlpro@gmail.com" ,DateOfBirth : new System.DateTime(2020,01,01),DepartmentId : 33, Department : "gironde" );
        EmployeeEntity eE = _mapper.Map<EmployeeEntity>(e);
        return Verify(eE).ModifySerialization(settings => {
            settings.DontScrubNumericIds();            
            }) ;

    }
}

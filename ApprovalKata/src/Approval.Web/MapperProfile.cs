using Approval.Shared.Data;
using Approval.Shared.ReadModels;
using AutoMapper;

namespace Approval.Web
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeEntity>()
                .MapRecordMember(empEnt => empEnt.Id,emp => emp.EmployeeId)
                .MapRecordMember(empEnt=> empEnt.DateOfBirth, emp => DateOnly.FromDateTime(emp.DateOfBirth));
        }
    }
}

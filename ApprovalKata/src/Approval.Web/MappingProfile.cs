using Approval.Shared.Data;
using Approval.Shared.ReadModels;
using AutoMapper;

namespace Approval.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeEntity>().ForCtorParam("Id", opt => opt.MapFrom(src => src.EmployeeId))
                .ForCtorParam("DateOfBirth", opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DateOfBirth)));
        }
    }
}

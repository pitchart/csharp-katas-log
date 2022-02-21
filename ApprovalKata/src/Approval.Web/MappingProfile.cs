using System.Linq.Expressions;
using Approval.Shared.Data;
using Approval.Shared.ReadModels;
using Approval.Shared.SalesForce;
using AutoMapper;
using AutoMapper.Internal;

namespace Approval.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeEntity>().ForCtorParam("Id", ept => ept.MapFrom(src => src.EmployeeId))
                .ForCtorParam("DateOfBirth", opt => opt.MapFrom(src => DateOnly.FromDateTime(src.DateOfBirth)));

            CreateMap<PersonAccount, IndividualParty>()
                .MapRecordMember(dest => dest.Title, src => src.Salutation)
                .MapRecordMember(dest => dest.Gender,
                    src => src.FinServ__Gender_pc == "M" ? Gender.Male : Gender.Female)
                .MapRecordMember(dest => dest.BirthCity, src => src.CityOfBirth__pc)
                .MapRecordMember(dest => dest.BirthDate, src => DateTime.Parse(src.PersonBirthdate).Date)
                .MapRecordMember(dest => dest.PepMep, src => bool.Parse(src.PEPMEPType_pc))
                .MapRecordMember(dest => dest.Documents, src => ToIdentityDocuments(src));
        }

        private static readonly Func<PersonAccount, IEnumerable<IdentityDocument>> ToIdentityDocuments = src =>
        {
            var documents = new List<IdentityDocument>
            {
                new IdentityDocument(Number: src.LegalDocumentNumber1__c, DocumentType: src.LegalDocumentName1__c,
                    ExpirationDate: DateTime.Parse(src.LegalDocumentExpirationDate1__c))
            };
            if (!string.IsNullOrEmpty(src.LegalDocumentNumber2__c))
            {
                documents.Add(new IdentityDocument(Number: src.LegalDocumentNumber2__c,
                    DocumentType: src.LegalDocumentName2__c,
                    ExpirationDate: DateTime.Parse(src.LegalDocumentExpirationDate2__c)));
            }

            return documents;
        };
    }

    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> MapRecordMember<TSource, TDestination, TMember>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, TMember>> destinationMember, Expression<Func<TSource, TMember>> sourceMember)
        {
            var memberName = ReflectionHelper.FindProperty(destinationMember).Name;
            return mappingExpression
                .ForMember(destinationMember, opt => opt.MapFrom(sourceMember))
                .ForCtorParam(memberName, opt => opt.MapFrom(sourceMember));
        }
    }
}

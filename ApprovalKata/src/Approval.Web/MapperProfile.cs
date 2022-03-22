using Approval.Shared.Data;
using Approval.Shared.ReadModels;
using Approval.Shared.SalesForce;
using AutoMapper;

namespace Approval.Web
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeEntity>()
                .MapRecordMember(dest => dest.Id, src => src.EmployeeId)
                .MapRecordMember(dest => dest.DateOfBirth, src => DateOnly.FromDateTime(src.DateOfBirth));

            CreateMap<PersonAccount, IndividualParty>()
                .MapRecordMember(dest => dest.Title, src => src.Salutation)
                .MapRecordMember(dest => dest.BirthCity, src => src.CityOfBirth__pc)
                .MapRecordMember(dest => dest.BirthDate, src => DateTime.Parse(src.PersonBirthdate).Date)
                .MapRecordMember(dest => dest.PepMep, src => bool.Parse(src.PEPMEPType_pc))
                .MapRecordMember(dest => dest.Documents, src => ToIdentityDocuments(src));
        }

        private static readonly Func<PersonAccount, IEnumerable<IdentityDocument>>
            ToIdentityDocuments = src =>
            {
                var documents = new List<IdentityDocument>
                {
                    new IdentityDocument(
                        Number: src.LegalDocumentNumber1__c,
                        DocumentType: src.LegalDocumentName1__c,
                        ExpirationDate: DateTime.Parse(src.LegalDocumentExpirationDate1__c)
                    )
                };

                if (!string.IsNullOrEmpty(src.LegalDocumentNumber2__c))
                {
                    documents.Add(
                        new IdentityDocument(
                            Number: src.LegalDocumentNumber2__c,
                            DocumentType: src.LegalDocumentName2__c,
                            ExpirationDate: DateTime.Parse(src.LegalDocumentExpirationDate2__c)
                        ));
                }

                return documents;
            };
    }
}

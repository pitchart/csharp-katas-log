using Approval.Shared.ReadModels;
using Approval.Shared.SalesForce;

namespace Approval.Web
{
    public static class DataBuilder
    {
        public static PersonAccount AlCapone() =>
            new PersonAccount(
                Name: "Capone",
                LastName: "Capone",
                Salutation: "Mr.",
                MiddleName: "",
                PersonBirthdate: "1899/01/25T08:30:06",
                FirstName: "Al",
                PEPMEPType_pc: "false",
                FinServ__Gender_pc: "M",
                CityOfBirth__pc: "Brooklyn",
                DeclaredMonthlySalary__c: "30000$",
                LegalDocumentExpirationDate1__c: "2000/01/05",
                LegalDocumentIssuingCountry1__c: "United States",
                LegalDocumentName1__c: "ID CARD",
                LegalDocumentNumber1__c: "89898*3234");

        public static PersonAccount Mesrine() =>
            new PersonAccount(
                Name: "Mesrine",
                LastName: "Mesrine",
                Salutation: "Mr.",
                MiddleName: "",
                PersonBirthdate: "1936/12/28T08:30:06",
                FirstName: "Jacques",
                PEPMEPType_pc: "true",
                FinServ__Gender_pc: "M",
                CityOfBirth__pc: "Clichy",
                DeclaredMonthlySalary__c: "0$",
                LegalDocumentExpirationDate1__c: "2020/09/30",
                LegalDocumentIssuingCountry1__c: "France",
                LegalDocumentName1__c: "ID CARD",
                LegalDocumentNumber1__c: "89AJQND8579",
                LegalDocumentExpirationDate2__c: "1990/12/23",
                LegalDocumentIssuingCountry2__c: "Contrebande",
                LegalDocumentName2__c: "FAKE PASSPORT",
                LegalDocumentNumber2__c: "Not a number");

        public static DynamicPerson Montana() =>
            new DynamicPerson(
                Id: Guid.NewGuid(),
                CreationDate: DateTime.Now,
                "Tony",
                LastName: "Montana"
            );
    }
}

namespace Approval.Shared.SalesForce
{
    public record PersonAccount(
        string Name,
        string LastName,
        string Salutation,
        string MiddleName,
        string PersonBirthdate,
        string FirstName,
        string PEPMEPType_pc,
        string FinServ__Gender_pc,
        string CityOfBirth__pc,
        string DeclaredMonthlySalary__c,
        string LegalDocumentExpirationDate1__c,
        string LegalDocumentIssuingCountry1__c,
        string LegalDocumentName1__c,
        string LegalDocumentNumber1__c,
        string LegalDocumentExpirationDate2__c = "",
        string LegalDocumentIssuingCountry2__c = "",
        string LegalDocumentIssuingDate2__c = "",
        string LegalDocumentName2__c = "",
        string LegalDocumentNumber2__c = "");
}

namespace Approval.Shared.ReadModels
{
    public record IndividualParty(
        string Title,
        string LastName,
        string FirstName,
        string MiddleName,
        string BirthCity,
        Gender Gender,
        DateTime BirthDate,
        bool PepMep,
        IEnumerable<IdentityDocument> Documents);
}

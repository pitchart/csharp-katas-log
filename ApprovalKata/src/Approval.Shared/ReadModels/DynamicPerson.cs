namespace Approval.Shared.ReadModels
{
    public record DynamicPerson(
        Guid Id,
        DateTime CreationDate,
        string FirstName,
        string LastName);
}

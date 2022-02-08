namespace Approval.Shared.ReadModels
{
    public record IdentityDocument(
        string Number,
        string DocumentType,
        DateTime ExpirationDate);
}

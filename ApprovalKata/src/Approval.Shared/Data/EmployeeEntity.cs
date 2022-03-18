namespace Approval.Shared.Data
{
    public record EmployeeEntity(
        int Id,
        string FirstName,
        string LastName,
        string Email,
        DateOnly DateOfBirth,
        int DepartmentId,
        string Department);
}

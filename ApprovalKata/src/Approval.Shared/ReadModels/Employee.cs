namespace Approval.Shared.ReadModels
{
    public record Employee(
        int EmployeeId,
        string FirstName,
        string LastName,
        string Email,
        DateTime DateOfBirth,
        int DepartmentId,
        string Department);
}

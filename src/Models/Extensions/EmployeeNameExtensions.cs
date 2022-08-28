namespace EmployeeTestcase.Models.Extensions;

public static class EmployeeExtensions
{
    public static string GetName(this IEmployee employee)
    {
        return $"{employee.Name.FirstName} {employee.Name.Surname}";
    }
}
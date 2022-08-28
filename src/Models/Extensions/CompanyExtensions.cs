namespace EmployeeTestcase.Models.Extensions;

public static class CompanyExtensions
{
    public static bool ContainsEmployee(this ICompany company, IEmployee employee)
    {
        return company.Employees.Any(x => x == employee);
    }

    public static void ShowAllEmployees(this ICompany company)
    {
        Console.WriteLine("{0,-30} {1,5}\n", "Name", "Experience");
        foreach (var employee in company.Employees)
        {
            Console.WriteLine(@"{0,-30}, {1,5}", employee.GetName(), employee.Experience);
        }

        // LINQ version
        // company.Employees.Select(x =>
        // {
        //     Console.WriteLine(@"{0,-30}, {1,5}", x.GetName(), x.Experience);
        //     return x;
        // });
    }
}
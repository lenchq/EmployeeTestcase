namespace EmployeeTestcase.Models;

public class Company : ICompany
{
    public EmployeeList Employees { get; set; }
    public bool ContainsEmployeeOfType<T>() where T : IEmployee
    {
        return Employees.Any(x => x.GetType() == typeof(T));
    }
    public EmployeeList GetEmployeesOfType<T>() where T : IEmployee
    {
        var e = (IList<IEmployee>)(Employees.Where(x => x.GetType() == typeof(T)).ToList<IEmployee>());
        return new EmployeeList(e);
    }

    public int CountEmployeesOfType<T>() where T : IEmployee
    {
        return Employees.Count(x => x.GetType() == typeof(T));
    }

    public Company()
    {
        Employees = new EmployeeList();
    }
}
namespace EmployeeTestcase.Models;

public interface ICompany
{
    public EmployeeList Employees { get; }

    public bool ContainsEmployeeOfType<T>() where T : IEmployee;
    public int CountEmployeesOfType<T>() where T : IEmployee;
}
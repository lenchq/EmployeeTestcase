namespace EmployeeTestcase.Models;

public class Worker : IEmployee
{
    public int Experience { get; set; }
    public IEmployeeName Name { get; set; }

    public void Work()
    {
        Console.WriteLine("Make products");
    }
}
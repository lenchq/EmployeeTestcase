namespace EmployeeTestcase.Models;

public class Foreman : IEmployee
{
    public int Experience { get; set; }
    public IEmployeeName Name { get; set; }

    public void Work()
    {
        Console.WriteLine("Buy materials");
    }

    public void CheckWorkers()
    {
        Console.WriteLine("Check workers to do their work");
    }
}
namespace EmployeeTestcase.Models;

public class Manager : IEmployee
{
    public int Experience { get; set; }
    public IEmployeeName Name { get; set; }

    public void Work()
    {
        Console.WriteLine("Collect orders");
    }

    public void GiveTask()
    {
        Console.WriteLine($"{Name} gave a task!");
    }
}
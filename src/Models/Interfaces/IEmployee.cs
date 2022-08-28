namespace EmployeeTestcase.Models;

public interface IEmployee
{
    
    public int Experience { get; set; }
    public IEmployeeName Name { get; set; }

    public void Work();
}
using static System.String;

namespace EmployeeTestcase.Models;

public class EmployeeName : IEmployeeName
{
    public string FirstName { get; set; }
    public string Surname { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">"Name Surname</param>
    /// <returns></returns>
    public static EmployeeName FromString(string name)
    {
        string?[] values = name.Split(' ');
        var n = values[0] ?? Empty;
        var s = values[1] ?? Empty;
        return new EmployeeName
        {
            FirstName = n,
            Surname = s
        };
    }

    public override string ToString()
    {
        return $"{FirstName} {Surname}";
    }
}
using EmployeeTestcase.Models;
using NUnit.Framework;

namespace EmployeeTestcaseTests;

[TestFixture]
public class EmployeeNameTests
{
    [SetUp]
    public void SetUp()
    {
        
    }
    
    [Test(TestOf = typeof(EmployeeName))]
    public void EmployeeNameTest()
    {
        var fname = Faker.Name.First();
        var sname = Faker.Name.Middle();
        var emplName = new EmployeeName()
        {
            FirstName = fname,
            Surname = sname
        };
        
        Assert.IsInstanceOf(typeof(EmployeeName), emplName);
        Assert.AreEqual(fname, emplName.FirstName);
        Assert.AreEqual(sname, emplName.Surname);
    }
    [Test(TestOf = typeof(EmployeeName))]
    public void EmployeeNameFromStringTest()
    {
        var fname = Faker.Name.First();
        var sname = Faker.Name.Middle();
        var str = $"{fname} {sname}";
        var emplName = EmployeeName.FromString(str);
        
        Assert.IsInstanceOf(typeof(EmployeeName), emplName);
        Assert.AreEqual(fname, emplName.FirstName);
        Assert.AreEqual(sname, emplName.Surname);
    }
    
}
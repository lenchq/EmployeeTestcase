using System;
using System.Linq;
using System.Runtime.CompilerServices;
using EmployeeTestcase.Models;
using Faker;
using NUnit.Framework;
using Company = EmployeeTestcase.Models.Company;

namespace EmployeeTestcaseTests;

[TestFixture(TestOf = typeof(EmployeeList))]
public class EmployeeListTests
{
    private IEmployee _randomEmployee()
    {
        switch (Random.Shared.Next(0, 2))
        {
            case 0:
                return _randomEmployee<Worker>();
            case 1:
                return _randomEmployee<Manager>();
            case 2:
                return _randomEmployee<Foreman>();
            default:
                return _randomEmployee<Worker>();
        }
    }
    private IEmployee _randomEmployee<T>() where T: IEmployee
    {
        var exp = Random.Shared.Next(100);
        var fname = Faker.Name.First();
        var sname = Faker.Name.Middle();
        var ename = new EmployeeName
        {
            FirstName = fname,
            Surname = sname
        };

        var employee = (T) Activator.CreateInstance(typeof(T))!;
        employee.Name = ename;
        employee.Experience = exp;

        return employee;
    }

    [Test]
    public void TetEmployeeList()
    {
        var list = new EmployeeList();
        
        Assert.IsFalse(list.IsReadOnly);
        var worker = _randomEmployee<Worker>();

        list += worker;
        list.Clear();
        Assert.AreEqual(list.Count, 0);
        Assert.IsFalse(list.Contains(worker));
        list += worker;
        Assert.IsTrue(list.Contains(worker));
        Assert.AreEqual(list.IndexOf(worker), 0);
        list.RemoveAt(0);
        Assert.AreEqual(list.Count, 0);
        Assert.IsFalse(list.Contains(worker));
        list = (list + _randomEmployee<Worker>()) + _randomEmployee<Manager>() + _randomEmployee<Foreman>();
        list.Insert(0, worker);
        Assert.IsTrue(list.Contains(worker));
        Assert.AreEqual(list.IndexOf(worker), 0);
        var index = list.IndexOf(worker);
        var empl = _randomEmployee();
        list[index] = empl;
        Assert.AreEqual(list[index], empl);
        Assert.AreNotEqual(list[index], worker);
        
    }
}
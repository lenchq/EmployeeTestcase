using System;
using System.Linq;
using System.Runtime.CompilerServices;
using EmployeeTestcase.Models;
using EmployeeTestcase.Models.Extensions;
using Faker;
using NUnit.Framework;
using Company = EmployeeTestcase.Models.Company;

namespace EmployeeTestcaseTests;

[TestFixture(TestOf = typeof(Company))]
public class CompanyTests
{
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
    public void TetCompanyCreate()
    {

        var exp = Random.Shared.Next(100);
        var fname = Faker.Name.First();
        var sname = Faker.Name.Middle();
        var ename = new EmployeeName
        {
            FirstName = fname,
            Surname = sname
        };

        var employee = new Worker
        {
            Experience = exp,
            Name = ename
        };
        var company = new Company()
        {
            Employees =
            {
                employee
            }
        };

        Assert.IsInstanceOf<Company>(company);
        Assert.AreSame(employee, company.Employees[0]);
        var e = _randomEmployee<Worker>();
        company.Employees += e;
        Assert.IsInstanceOf<Worker>(company.Employees[^1]);
        Assert.AreSame(e, company.Employees[^1]);

        Assert.IsFalse(company.ContainsEmployeeOfType<Manager>());
        Assert.AreEqual(company.CountEmployeesOfType<Manager>(), 0);
        Assert.AreEqual(company.GetEmployeesOfType<Manager>().ToArray(), Array.Empty<Manager>());
        var mngr = _randomEmployee<Manager>();
        company.Employees += mngr;
        Assert.IsTrue(company.ContainsEmployee(mngr));
        Assert.IsTrue(company.ContainsEmployeeOfType<Manager>());
        Assert.AreEqual(company.CountEmployeesOfType<Manager>(), 1);
        Assert.AreEqual(company.GetEmployeesOfType<Manager>().ToArray().Length, 1);
        Assert.AreEqual(company.GetEmployeesOfType<Manager>().ToArray()[0], mngr);
        
        company.Employees -= mngr;
        Assert.IsFalse(company.ContainsEmployeeOfType<Manager>());
        Assert.AreEqual(company.CountEmployeesOfType<Manager>(), 0);
        Assert.AreEqual(company.GetEmployeesOfType<Manager>().ToArray(), Array.Empty<Manager>());
        
        Assert.DoesNotThrow(() => company.ShowAllEmployees());
    }
}
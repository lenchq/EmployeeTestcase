using System;
using EmployeeTestcase.Models;
using EmployeeTestcase.Models.Extensions;
using NUnit.Framework;

namespace EmployeeTestcaseTests;

[TestFixture]   
public class EmployeeCreateTests
{
    private Random rnd;
    
    [SetUp]
    public void SetUp()
    {
        rnd = new Random(Random.Shared.Next(int.MinValue, int.MaxValue));
    }
    
    [Test(TestOf = typeof(Worker))]
    public void CreateEmployeeWorker()
    {
        var exp = rnd.Next(100);
        var fname = Faker.Name.First();
        var sname = Faker.Name.Middle();
        var str = $"{fname} {sname}";
        var emplName = EmployeeName.FromString(str);
        var worker = new Worker
        {
            Experience = exp,
            Name = emplName
        };
        
        Assert.IsInstanceOf<IEmployee>(worker);
        Assert.IsInstanceOf<Worker>(worker);
        Assert.AreEqual(fname, worker.Name.FirstName);
        Assert.AreEqual(sname, worker.Name.Surname);
        Assert.AreEqual(emplName, worker.Name);
        Assert.AreEqual(exp, worker.Experience);
        Assert.DoesNotThrow(() => worker.Work());
    }
    [Test(TestOf = typeof(Foreman))]
    public void CreateEmployeeForeman()
    {
        var exp = rnd.Next(100);
        var fname = Faker.Name.First();
        var sname = Faker.Name.Middle();
        var str = $"{fname} {sname}";
        var emplName = EmployeeName.FromString(str);
        var foreman = new Foreman
        {
            Experience = exp,
            Name = emplName
        };
        
        Assert.IsInstanceOf<IEmployee>(foreman);
        Assert.IsInstanceOf<Foreman>(foreman);
        Assert.AreEqual(fname, foreman.Name.FirstName);
        Assert.AreEqual(sname, foreman.Name.Surname);
        Assert.AreEqual(emplName, foreman.Name);
        Assert.AreEqual(exp, foreman.Experience);
        Assert.DoesNotThrow(() => foreman.Work());
        Assert.DoesNotThrow(() => foreman.CheckWorkers());
    }
    [Test(TestOf = typeof(Manager))]
    public void CreateEmployeeManager()
    {
        var exp = rnd.Next(100);
        var fname = Faker.Name.First();
        var sname = Faker.Name.Middle();
        var str = $"{fname} {sname}";
        var emplName = EmployeeName.FromString(str);
        var manager = new Manager
        {
            Experience = exp,
            Name = emplName
        };
        
        Assert.IsInstanceOf<IEmployee>(manager);
        Assert.IsInstanceOf<Manager>(manager);
        Assert.AreEqual(fname, manager.Name.FirstName);
        Assert.AreEqual(sname, manager.Name.Surname);
        Assert.AreEqual(emplName, manager.Name);
        Assert.AreEqual(exp, manager.Experience);
        Assert.DoesNotThrow(() => manager.Work());
        Assert.DoesNotThrow(() => manager.GiveTask());
    }

    [Test]
    public void EmployeeNameFromStringTest()
    {
        var fname = Faker.Name.First();
        var sname = Faker.Name.Middle();
        var str = $"{fname} {sname}";
        var emplName = EmployeeName.FromString(str);

        var w = new Worker()
        {
            Name = emplName,
            Experience = 0
        };
        var name = w.GetName();
        
        Assert.AreEqual(str, name);
    }
}
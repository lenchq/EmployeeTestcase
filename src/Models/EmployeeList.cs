using System.Collections;

namespace EmployeeTestcase.Models;

public class EmployeeList : IList<IEmployee>
{
    private List<IEmployee> _employees;

    public EmployeeList()
    {
        _employees = new List<IEmployee>();
    }

    public EmployeeList(IEnumerable<IEmployee> list)
    {
        _employees = new List<IEmployee>(list);
    }

    public void Add(IEmployee item)
    {
        _employees.Add(item);
    }

    public void Clear() => _employees.Clear();

    public bool Contains(IEmployee item) => _employees.Contains(item);

    public void CopyTo(IEmployee[] array, int arrayIndex) => _employees.CopyTo(array, arrayIndex);

    public bool Remove(IEmployee item) => _employees.Remove(item);

    public int Count { get => _employees.Count; }
    public bool IsReadOnly { get => false; }

    public int IndexOf(IEmployee item) => _employees.IndexOf(item);

    public void Insert(int index, IEmployee item) => _employees.Insert(index ,item);

    public void RemoveAt(int index) => _employees.RemoveAt(index);

    public IEmployee this[int index]
    {
        get => _employees[index];
        set => _employees[index] = value;
    }

    public static EmployeeList operator +(EmployeeList left, IEmployee right)
    {
        left.Add(right);
        return left;
    }

    public static EmployeeList operator -(EmployeeList left, IEmployee right)
    {
        left.Remove(right);
        return left;
    }

    IEnumerator<IEmployee> IEnumerable<IEmployee>.GetEnumerator()
    {
        return _employees.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _employees.GetEnumerator();
    }
}
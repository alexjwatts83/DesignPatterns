namespace DesignPatterns.Domain.Creational.PrototypePattern;

public interface IDeepCopyable<T> where T : new()
{
    void CopyTo(T target);

    // new to C#
    public T DeepCopy()
    {
        T t = new T();
        CopyTo(t);
        return t;
    }
}

public static class DeepCopyExtensions
{
    public static T DeepCopy<T>(this IDeepCopyable<T> item)
      where T : new()
    {
        return item.DeepCopy();
    }

    public static T DeepCopy<T>(this T person)
      where T : Person, new()
    {
        return ((IDeepCopyable<T>)person).DeepCopy();
    }
}

public class Address2 : IDeepCopyable<Address2>
{
    public string StreetName;
    public int HouseNumber;

    //public Address2(string streetName, int houseNumber)
    //{
    //    StreetName = streetName;
    //    HouseNumber = houseNumber;
    //}

    //public Address2()
    //{

    //}

    public override string ToString()
    {
        return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
    }

    public void CopyTo(Address2 target)
    {
        target.StreetName = StreetName;
        target.HouseNumber = HouseNumber;
    }
}

public class Person : IDeepCopyable<Person>
{
    public string[] Names;
    public Address2 Address;

    public string Name { get { return string.Join(" ", Names); } }

    //public Person()
    //{

    //}

    //public Person(string[] names, Address2 address)
    //{
    //    Names = names;
    //    Address = address;
    //}

    public override string ToString()
    {
        return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
    }

    public virtual void CopyTo(Person target)
    {
        target.Names = (string[])Names.Clone();
        target.Address = Address.DeepCopy();
    }
}

public class Employee2 : Person, IDeepCopyable<Employee2>
{
    public int Salary;

    public void CopyTo(Employee2 target)
    {
        base.CopyTo(target);
        target.Salary = Salary;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
    }
}

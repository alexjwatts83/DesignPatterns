﻿namespace DesignPatterns.Domain.Creational.PrototypePattern;

public class Address
{
    public string StreetAddress, City, Country;

    public Address(string streetAddress, string city, string country)
    {
        StreetAddress = streetAddress ?? throw new ArgumentNullException(paramName: nameof(streetAddress));
        City = city ?? throw new ArgumentNullException(paramName: nameof(city));
        Country = country ?? throw new ArgumentNullException(paramName: nameof(country));
    }

    public Address(Address other)
    {
        StreetAddress = other.StreetAddress;
        City = other.City;
        Country = other.Country;
    }

    public override string ToString()
    {
        return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(City)}: {City}, {nameof(Country)}: {Country}";
    }
}

public class Employee
{
    //public string Name;
    public string[] Names;
    public string Name { get {  return string.Join(" ", Names); } }

    public Address Address;

    public Employee(string[] names, Address address)
    {
        Names = names ?? throw new ArgumentNullException(paramName: nameof(names));
        Address = address ?? throw new ArgumentNullException(paramName: nameof(address));
    }

    public Employee(Employee other)
    {
        Names = other.Names;
        Address = new Address(other.Address);
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
    }
}
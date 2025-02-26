using DesignPatterns.Domain.Creational.PrototypePattern;

namespace DesignPatterns.Domain.Tests.Creational.PrototypePattern;

public class PrototypeInheritanceTests
{
    [Fact()]
    public void ToStringTest()
    {
        // arrange
        var john = new Employee2
        {
            Names = ["John", "Doe"],
            Address = new Address2 { HouseNumber = 123, StreetName = "London Road" },
            Salary = 321000
        };
        var copy = john.DeepCopy();

        // act
        copy.Names[1] = "Smith";
        copy.Address.HouseNumber = 456;
        copy.Salary = 123000;

        // assert
        john.Name.ShouldBe("John Doe");
        john.Address.HouseNumber.ShouldBe(123);
        john.Address.StreetName.ShouldBe("London Road");
        john.Salary.ShouldBe(321000);

        copy.Name.ShouldBe("John Smith");
        copy.Address.HouseNumber.ShouldBe(456);
        copy.Address.StreetName.ShouldBe("London Road");
        copy.Salary.ShouldBe(123000);
    }
}
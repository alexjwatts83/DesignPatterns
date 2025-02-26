using DesignPatterns.Domain.Creational.PrototypePattern;

namespace DesignPatterns.Domain.Tests.Creational.PrototypePattern;

public class CopyConstructorsTests
{
    [Fact()]
    public void CopyConstructorsTest()
    {
        // arrange
        var original = new Employee(["John", "Smith"], new Address("123 London Road", "London", "UK"));

        // act
        var copy = new Employee(original);
        copy.Names = ["Jane", "Doe"];
        copy.Address.StreetAddress = "1465 Rose Street";
        copy.Address.City = "Burr Ridge";
        copy.Address.Country= "US";

        // assert
        original.Name.ShouldBe("John Smith");
        original.Address.StreetAddress.ShouldBe("123 London Road");
        original.Address.City.ShouldBe("London");
        original.Address.Country.ShouldBe("UK");

        copy.Name.ShouldBe("Jane Doe");
        copy.Address.StreetAddress.ShouldBe("1465 Rose Street");
        copy.Address.City.ShouldBe("Burr Ridge");
        copy.Address.Country.ShouldBe("US");
    }
}
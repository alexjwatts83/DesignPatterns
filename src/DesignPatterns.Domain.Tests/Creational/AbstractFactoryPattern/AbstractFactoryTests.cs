using DesignPatterns.Domain.Creational.AbstractFactoryPattern;

namespace DesignPatterns.Domain.Tests.Creational.AbstractFactoryPattern;

public class AbstractFactoryTests
{
    [Theory]
    [InlineData("Coffee")]
    [InlineData("Tea")]
    public void MakeDrinkTest(string type)
    {
        // arrange
        var machine = new HotDrinkMachine();

        // act
        var result = machine.MakeDrink(type, 100);

        // assert
        result.ShouldNotBeNull();
        if (type == "Coffee")
        {
            result.ShouldBeOfType<Coffee>();
        }
        if (type == "Tea")
        {
            result.ShouldBeOfType<Tea>();
        }
    }
}
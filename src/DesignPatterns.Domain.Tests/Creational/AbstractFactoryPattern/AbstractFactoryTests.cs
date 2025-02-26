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

    [Fact]
    public void MakeDrinkInvalidTypeException()
    {
        // arrange
        var machine = new HotDrinkMachine();

        // act
        var result = Should.Throw<InvalidOperationException>(() => machine.MakeDrink("INVALID", 100));

        // assert
        result.Message.ShouldBe("Drink type of 'INVALID' is not a valid type");
    }

    [Fact]
    public void MakeDrinkInvalidAmountException()
    {
        // arrange
        var machine = new HotDrinkMachine();

        // act
        var result = Should.Throw<InvalidOperationException>(() => machine.MakeDrink(nameof(Tea), -100));

        // assert
        result.Message.ShouldBe("Amount must be greater than 0 but was -100");
    }
}
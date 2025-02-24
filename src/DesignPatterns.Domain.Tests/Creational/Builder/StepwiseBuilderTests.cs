using Shouldly;
using Xunit;

namespace DesignPatterns.Domain.Creational.Builder.Tests;

public class StepwiseBuilderTests
{
    [Fact()]
    public void CreateTest()
    {
        // arrange
        // act
        var car = CarBuilder.Create()
          .OfType(CarType.Crossover)
          .OfBrand("Toyota")
          .WithWheels(18)
          .Build();

        // assert
        car.Type.ShouldBe(CarType.Crossover);
        car.Brand.ShouldBe("Toyota");
        car.WheelSize.ShouldBe(18);
    }
}
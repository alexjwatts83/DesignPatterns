using DesignPatterns.Domain.Creational.Builder;

namespace DesignPatterns.Domain.Tests.Creational.Builder;

public class FunctionalBuilderTests
{
    [Fact()]
    public void AnimalFunctionalBuilder_BuildTest()
    {
        // arrange
        // act
        var result = new AnimalFunctionalBuilder()
            .WithName("Lion")
            .WithType(AnimalType.Carnivore)
            .Build();

        // assert
        result.ShouldNotBeNull();
        result.Name.ShouldBe("Lion");
        result.AnimalType.ShouldBe(AnimalType.Carnivore);
    }
}
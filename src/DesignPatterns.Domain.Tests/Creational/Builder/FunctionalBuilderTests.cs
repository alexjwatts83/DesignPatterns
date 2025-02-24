using DesignPatterns.Domain.Creational.Builder;

namespace DesignPatterns.Domain.Tests.Creational.Builder;

public class FunctionalBuilderTests
{
    [Fact()]
    public void AnimalFunctionalBuilder_BuildTest()
    {
        // arrange
        // act
        const string description = "King of the Jungle but doesn't live in the Jungle.";
        var result = new AnimalFunctionalBuilder()
            .WithName("Lion")
            .WithType(AnimalType.Carnivore).WithDescription(description)
            .Build();

        // assert
        result.ShouldNotBeNull();
        result.Name.ShouldBe("Lion");
        result.AnimalType.ShouldBe(AnimalType.Carnivore);
        result.Description.ShouldBe(description);
    }
}
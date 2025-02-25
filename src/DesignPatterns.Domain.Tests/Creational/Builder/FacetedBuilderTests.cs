using DesignPatterns.Domain.Creational.Builder;

namespace DesignPatterns.Domain.Tests.Creational.Builder;

public class FacetedBuilderTests
{
    [Fact()]
    public void EarningTest()
    {
        // arrange
        // act
        var builder = new CitizenBuilder();
        Citizen result = builder
            .Named("King Charles")
            .Lives
                .At("123 London Road")
                .In("London")
                .WithPostcode("SW12BC")
            .Works
                .At("Fabrikam")
                .AsA("Engineer")
                .Earning(123000);

        // assert
        result.ShouldNotBeNull();
        result.Name.ShouldBe("King Charles");
        // address
        result.StreetAddress.ShouldBe("123 London Road");
        result.Postcode.ShouldBe("SW12BC");
        result.City.ShouldBe("London");
        // employment
        result.CompanyName.ShouldBe("Fabrikam");
        result.Position.ShouldBe("Engineer");
        result.AnnualIncome.ShouldBe(123000);
    }
}
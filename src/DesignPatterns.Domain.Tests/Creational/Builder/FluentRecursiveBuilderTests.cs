using Xunit;
using Shouldly;
using DesignPatterns.Domain.Creational.Builder;

namespace DesignPatterns.Domain.Tests.Creational.Builder;

public class FluentRecursiveBuilderTests
{
    [Fact()]
    public void BuildTest()
    {
        // arrange
        // act
        var dob = new DateTime(1975, 7, 1);
        var result = Person.New
          .Called("Clark Kent")
          .WorksAsA("Daily Planet")
          .Born(dob)
          .Build();

        // assert
        result.Name.ShouldBe("Clark Kent");
        result.Position.ShouldBe("Daily Planet");
        result.DateOfBirth.ShouldBe(dob);
    }
}
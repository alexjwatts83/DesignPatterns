using DesignPatterns.Domain.Creational.SingletonPattern;

namespace DesignPatterns.Domain.Tests.Creational.SingletonPattern;

public class SingletonLazyTests
{
    [Fact()]
    public void GetPopulationTest()
    {
        // arrange
        // act
        var db1 = SingletonDatabase.Instance;
        var db2 = SingletonDatabase.Instance;

        // assert
        db1.ShouldBeSameAs(db2);
        SingletonDatabase.Count.ShouldBe(1);
    }
}
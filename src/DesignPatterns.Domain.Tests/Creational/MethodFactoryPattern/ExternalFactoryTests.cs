namespace DesignPatterns.Domain.Creational.MethodFactoryPattern.Tests;

public class ExternalFactoryTests
{
    [Fact()]
    public void NewCartesianPointTest()
    {
        // arrange
        // act
        var point = Point2Factory.NewCartesianPoint(100, 200);

        // assert
        point.X.ShouldBe(100);
        point.Y.ShouldBe(200);
    }

    [Fact()]
    public void NewPolarPointTest()
    {
        // arrange
        // act
        var point = Point2Factory.NewPolarPoint(100, 200);

        // assert
        point.X.ShouldBe(100 * Math.Cos(200));
        point.Y.ShouldBe(100 * Math.Sin(200));
    }
}
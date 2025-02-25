namespace DesignPatterns.Domain.Creational.MethodFactoryPattern.Tests;

public class MethodFactoryTests
{
    [Fact()]
    public void NewCartesianPointTest()
    {
        // arrange
        // act
        var cartesianPoint = Point.NewCartesianPoint(100, 200);

        // assert
        cartesianPoint.X.ShouldBe(100);
        cartesianPoint.Y.ShouldBe(200);
    }

    [Fact()]
    public void NewPolarPointTest()
    {
        // arrange
        // act
        var cartesianPoint = Point.NewPolarPoint(100, 200);

        // assert
        cartesianPoint.X.ShouldBe(100 * Math.Cos(200));
        cartesianPoint.Y.ShouldBe(100 * Math.Sin(200));
    }
}
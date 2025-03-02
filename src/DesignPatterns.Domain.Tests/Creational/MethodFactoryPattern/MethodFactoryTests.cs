﻿namespace DesignPatterns.Domain.Creational.MethodFactoryPattern.Tests;

public class MethodFactoryTests
{
    [Fact()]
    public void NewCartesianPointTest()
    {
        // arrange
        // act
        var point = Point.NewCartesianPoint(100, 200);

        // assert
        point.X.ShouldBe(100);
        point.Y.ShouldBe(200);
    }

    [Fact()]
    public void NewPolarPointTest()
    {
        // arrange
        // act
        var point = Point.NewPolarPoint(100, 200);

        // assert
        point.X.ShouldBe(100 * Math.Cos(200));
        point.Y.ShouldBe(100 * Math.Sin(200));
    }
}
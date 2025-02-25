namespace DesignPatterns.Domain.Creational.MethodFactoryPattern;

public class Point2
{
    public double X { get; set; }
    public double Y { get; set; }

    internal Point2(double x, double y)
    {
        X = x;
        Y = y;
    }
}

public class Point2Factory
{
    public static Point2 NewCartesianPoint(double x, double y)
    {
        return new Point2(x, y);
    }

    public static Point2 NewPolarPoint(double rho, double theta)
    {
        return new Point2(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }
}
namespace DesignPatterns.Domain.Creational.MethodFactoryPattern;

public enum CoordinateSystem
{
    Cartesian,
    Polar
}

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    protected Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    //public Point(double a, double b, // names do not communicate intent
    //    CoordinateSystem cs = CoordinateSystem.Cartesian)
    //{
    //    switch (cs)
    //    {
    //        case CoordinateSystem.Polar:
    //            X = a * Math.Cos(b);
    //            Y = a * Math.Sin(b);
    //            break;
    //        default:
    //            X = a;
    //            Y = b;
    //            break;
    //    }

    //    // steps to add a new system
    //    // 1. augment CoordinateSystem
    //    // 2. change ctor
    //}

    public static Point NewCartesianPoint(double x, double y)
    {
        return new Point(x, y);
    }

    public static Point NewPolarPoint(double rho, double theta)
    {
        return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }
}

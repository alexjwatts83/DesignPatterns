namespace DesignPatterns.Domain.Creational.MethodFactoryPattern;

public class Point3
{
    public double X { get; set; }
    public double Y { get; set; }

    private Point3(double x, double y)
    {
        X = x;
        Y = y;
    }

    public static class Factory
    {
        public static Point3 NewCartesianPoint(double x, double y) => new(x, y);

        public static Point3 NewPolarPoint(double rho, double theta)
        {
            return new Point3(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
}
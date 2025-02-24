namespace DesignPatterns.Domain.Creational.Builder;

public enum CarType
{
    Sedan,
    Crossover
}

public class Car
{
    public CarType Type { get; set; }
    public string Brand { get; set; } = string.Empty;
    public int WheelSize { get; set; }
}

public interface ISpecifyCarType
{
    public ISpecifyBrand OfType(CarType type);
}

public interface ISpecifyBrand
{
    public ISpecifyWheelSize OfBrand(string brand);
}

public interface ISpecifyWheelSize
{
    public IBuildCar WithWheels(int size);
}

public interface IBuildCar
{
    public Car Build();
}

public class CarBuilder
{
    public static ISpecifyCarType Create()
    {
        return new Impl();
    }

    private class Impl :
        ISpecifyCarType,
        ISpecifyBrand,
        ISpecifyWheelSize,
        IBuildCar
    {
        private readonly Car car = new();

        public ISpecifyBrand OfType(CarType type)
        {
            car.Type = type;
            return this;
        }

        public IBuildCar WithWheels(int size)
        {
            switch (car.Type)
            {
                case CarType.Crossover when size < 17 || size > 20:
                case CarType.Sedan when size < 15 || size > 17:
                    throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
            }
            car.WheelSize = size;
            return this;
        }

        public ISpecifyWheelSize OfBrand(string brand)
        {
            car.Brand = brand;
            return this;
        }

        public Car Build()
        {
            return car;
        }
    }
}

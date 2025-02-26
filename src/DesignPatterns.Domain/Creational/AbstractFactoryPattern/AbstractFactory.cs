namespace DesignPatterns.Domain.Creational.AbstractFactoryPattern;

public interface IHotDrink
{
    string Name { get; }
    void Consume();
}

internal class Tea : IHotDrink
{
    public string Name { get => nameof(Tea); }
    public void Consume()
    {
        Console.WriteLine("This tea is nice but I'd prefer it with milk.");
    }
}

internal class Coffee : IHotDrink
{
    public string Name { get => nameof(Coffee); }
    public void Consume()
    {
        Console.WriteLine("This coffee is delicious!");
    }
}

public interface IHotDrinkFactory
{
    IHotDrink Prepare(int amount);
}

internal class TeaFactory : IHotDrinkFactory
{
    public IHotDrink Prepare(int amount)
    {
        Console.WriteLine($"Put in tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
        return new Tea();
    }
}

internal class CoffeeFactory : IHotDrinkFactory
{
    public IHotDrink Prepare(int amount)
    {
        Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
        return new Coffee();
    }
}

public class HotDrinkMachine
{
    private readonly Dictionary<string, IHotDrinkFactory> namedFactories = [];

    public HotDrinkMachine()
    {
        //foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
        //{
        //  var factory = (IHotDrinkFactory) Activator.CreateInstance(
        //    Type.GetType("DotNetDesignPatternDemos.Creational.AbstractFactory." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory"));
        //  factories.Add(drink, factory);
        //}

        foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
        {
            if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
            {
                var name = t.Name.Replace("Factory", string.Empty);
                var factory = Activator.CreateInstance(t) as IHotDrinkFactory;
                namedFactories.Add(name, factory!);
            }
        }
    }

    public IHotDrink MakeDrink(string type, int amount)
    {
        if (!namedFactories.ContainsKey(type))
            throw new InvalidOperationException($"Drink type of '{type}' is not a valid type");

        if (amount <= 0)
            throw new InvalidOperationException($"Amount must be greater than 0 but was {amount}");

        return namedFactories[type].Prepare(amount);
    }
}

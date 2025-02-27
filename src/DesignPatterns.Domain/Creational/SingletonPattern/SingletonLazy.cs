namespace DesignPatterns.Domain.Creational.SingletonPattern;

public interface IDatabase
{
    int GetPopulation(string name);
}

public class SingletonDatabase : IDatabase
{
    private readonly Dictionary<string, int> capitals;
    private static int instanceCount;
    public static int Count => instanceCount;

    private SingletonDatabase()
    {
        capitals = [];
    }

    public int GetPopulation(string name)
    {
        return capitals[name];
    }

    // laziness + thread safety
    private static Lazy<SingletonDatabase> instance = new(() =>
    {
        instanceCount++;
        return new SingletonDatabase();
    });

    public static IDatabase Instance => instance.Value;
}

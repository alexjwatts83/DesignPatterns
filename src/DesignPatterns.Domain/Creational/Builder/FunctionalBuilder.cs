namespace DesignPatterns.Domain.Creational.Builder;

public enum AnimalType
{
    Herbivore,
    Carnivore
}

public class Animal
{
    public string Name { get; set; }
    public AnimalType AnimalType { get; set; }
}

public abstract class FunctionalBuilder<TEntity, TSelf>
    where TSelf : FunctionalBuilder<TEntity, TSelf>
    where TEntity : new()
{
    private readonly List<Func<TEntity, TEntity>> actions = [];

    private TSelf AddAction(Action<TEntity> action)
    {
        actions.Add(x =>
        {
            action(x);
            return x;
        });

        return (TSelf)this;
    }

    public TSelf Do(Action<TEntity> action) => AddAction(action);

    public TEntity Build()
    {
        var entity = Activator.CreateInstance(typeof(TEntity));
        _ = actions.Aggregate(entity, static (p, f) => f((TEntity)p));

        return (TEntity)entity;
    }
}
public sealed class AnimalFunctionalBuilder :
    FunctionalBuilder<Animal, AnimalFunctionalBuilder>
{
    public AnimalFunctionalBuilder WithName(string name)
    {
        return Do(p => { p.Name = name; });
    }

    public AnimalFunctionalBuilder WithType(AnimalType type)
    {
        return Do(p => { p.AnimalType = type; });
    }
}
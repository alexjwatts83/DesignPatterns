using System.Reflection.Emit;
using System.Reflection;

namespace DesignPatterns.Domain.Creational.Builder;

public enum AnimalType
{
    Herbivore,
    Carnivore
}

public class Animal
{
    public string Name { get; set; } = string.Empty;
    public AnimalType AnimalType { get; set; }
    public string Description { get; set; } = string.Empty;
}

public abstract class FunctionalBuilder<TEntity, TSelf>
    where TSelf : FunctionalBuilder<TEntity, TSelf>
    where TEntity : new()
{
    private delegate object ClassCreator();
    private static readonly Dictionary<string, ClassCreator> ClassCreators = [];

    private readonly List<Func<TEntity, TEntity>> actions = [];

    private static ClassCreator GetClassCreator(string typeName)
    {
        // get delegate from dictionary
        if (ClassCreators.TryGetValue(typeName, out ClassCreator? value))
            return value;

        // get the default constructor of the type
        Type t = Type.GetType(typeName!)!;
        ConstructorInfo ctor = t.GetConstructor([])!;

        // create a new dynamic method that constructs and returns the type
        string methodName = t.Name + "Ctor";
        DynamicMethod dm = new(methodName, t, [], typeof(object).Module);
        ILGenerator lgen = dm.GetILGenerator();
        lgen.Emit(OpCodes.Newobj, ctor);
        lgen.Emit(OpCodes.Ret);

        // add delegate to dictionary and return
        ClassCreator creator = (ClassCreator)dm.CreateDelegate(typeof(ClassCreator));
        ClassCreators.Add(typeName, creator);

        // return a delegate to the method
        return creator;
    }

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
        var typeName = typeof(TEntity).FullName;
        ClassCreator classCreator = GetClassCreator(typeName!);
        var entity = classCreator();
        //var entity = Activator.CreateInstance();
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

public static class AnimalFunctionalBuilderExtensions
{
    public static AnimalFunctionalBuilder WithDescription
      (this AnimalFunctionalBuilder builder, string description)
    {
        builder.Do(p =>
        {
            p.Description = description;
        });

        return builder;
    }
}
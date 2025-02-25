namespace DesignPatterns.Domain.Creational.Builder;

public class Citizen
{
    public string Name { get; set; } = string.Empty;

    // address
    public string StreetAddress { get; set; } = string.Empty;
    public string Postcode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    // employment
    public string CompanyName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;

    public int AnnualIncome { get; set; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
    }
}

public class CitizenBuilder // facade 
{
    // the object we're going to build
    protected Citizen citizen = new(); // this is a reference!

    public CitizenBuilder Named(string name)
    {
        citizen.Name = name;
        return this;
    }

    public CitizenAddressBuilder Lives => new(citizen);
    public CitizenJobBuilder Works => new(citizen);

    public static implicit operator Citizen(CitizenBuilder cb)
    {
        return cb.citizen;
    }
}

public class CitizenJobBuilder : CitizenBuilder
{
    public CitizenJobBuilder(Citizen citizen)
    {
        this.citizen = citizen;
    }

    public CitizenJobBuilder At(string companyName)
    {
        citizen.CompanyName = companyName;
        return this;
    }

    public CitizenJobBuilder AsA(string position)
    {
        citizen.Position = position;
        return this;
    }

    public CitizenJobBuilder Earning(int annualIncome)
    {
        citizen.AnnualIncome = annualIncome;
        return this;
    }
}

public class CitizenAddressBuilder : CitizenBuilder
{
    // might not work with a value type!
    public CitizenAddressBuilder(Citizen Citizen)
    {
        this.citizen = Citizen;
    }

    public CitizenAddressBuilder At(string streetAddress)
    {
        citizen.StreetAddress = streetAddress;
        return this;
    }

    public CitizenAddressBuilder WithPostcode(string postcode)
    {
        citizen.Postcode = postcode;
        return this;
    }

    public CitizenAddressBuilder In(string city)
    {
        citizen.City = city;
        return this;
    }
}

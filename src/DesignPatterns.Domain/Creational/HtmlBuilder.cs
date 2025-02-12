namespace DesignPatterns.Domain.Creational;

public class HtmlBuilder
{
    private readonly HtmlElement root;

    public HtmlBuilder(string rootName)
    {
        root = new HtmlElement()
        {
            Name = rootName
        };
    }

    public HtmlBuilder WithChild(string childName, string childText)
    {
        var e = new HtmlElement(childName, childText);
        root.Elements.Add(e);
        return this;
    }

    public HtmlElement Build()
    {
        return root;
    }
}


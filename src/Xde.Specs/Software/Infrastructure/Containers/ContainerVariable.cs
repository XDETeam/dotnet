namespace Xde.Software.Infrastructure.Containers;

public class ContainerVariable
{
    public string Name { get; set; }

    public string Value { get; set; }

    public string Description { get; set; }

    public ContainerVariable(string name, string value, string description = null)
    {
        Name = name;
        Value = value;
        Description = description;
    }
}

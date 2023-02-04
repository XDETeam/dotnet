namespace Xde.Software.Infrastructure.Containers;

public class ContainerVariable
    : IContainerResource
{
    string IContainerResource.Name { get; set; }

    public string Value { get; set; }

    public string Description { get; set; }

    public ContainerVariable(string name, string value, string description = null)
    {
        (this as IContainerResource).Name = name;
        Value = value;
        Description = description;
    }
}

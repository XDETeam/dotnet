namespace Xde.Software.Infrastructure.Services;

public class EnvironmentVariable
{
    public string Name { get; set; }

    public string Value { get; set; }

    public string? Description { get; set; }

    public EnvironmentVariable(string name, string value, string? description = null)
    {
        Name = name;
        Value = value;
        Description = description;
    }
}

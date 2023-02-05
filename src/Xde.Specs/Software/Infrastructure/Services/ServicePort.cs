namespace Xde.Software.Infrastructure.Services;

public class ServicePort
{
    public int Port { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public ServicePort(int port, string? name = null, string? description = null)
    {
        Port = port;
        Name = name;
        Description = description;
    }
}

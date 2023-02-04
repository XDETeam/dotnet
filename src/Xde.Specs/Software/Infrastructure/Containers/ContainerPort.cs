namespace Xde.Software.Infrastructure.Containers;

/// <summary>
/// Container port
/// </summary>
/// 
/// <remarks>
/// Network port exposed from container.
/// </remarks>
public class ContainerPort
    : IContainerResource
{
    string IContainerResource.Name { get; set; }


    public int Port { get; set; }

    public string Description { get; set; }

    public ContainerPort(int port)
    {
        Port = port;
    }

    public ContainerPort(string serviceName, int port, string description = null)
    {
        (this as IContainerResource).Name = serviceName;
        Port = port;
        Description = description;
    }
}

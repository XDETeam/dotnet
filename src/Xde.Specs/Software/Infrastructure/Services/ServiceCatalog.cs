namespace Xde.Software.Infrastructure.Services;

public class ServiceCatalog
{
    public IEnumerable<IService> Services { get; }

    public ServiceCatalog(IEnumerable<IService> services)
    {
        Services = services;
    }
}

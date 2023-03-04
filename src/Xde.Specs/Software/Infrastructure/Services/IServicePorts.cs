namespace Xde.Software.Infrastructure.Services;

/// <summary>
/// Service ports
/// </summary>
/// <typeparam name="TService">
/// Type of the service for which ports are defined.
/// </typeparam>
public interface IServicePorts<TService>
    where TService : IService
{
    /// <summary>
    /// Service ports
    /// </summary>
    ServicePort[] Ports { get; }
}

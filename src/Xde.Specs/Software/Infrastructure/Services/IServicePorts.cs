namespace Xde.Software.Infrastructure.Services;

/// <summary>
/// Service ports
/// </summary>
/// <typeparam name="TService">
/// Type of the service for which ports are defined.
/// </typeparam>
public interface IServicePorts<TService>
{
    /// <summary>
    /// Service ports
    /// </summary>
    ServicePort[] Ports { get; }
}

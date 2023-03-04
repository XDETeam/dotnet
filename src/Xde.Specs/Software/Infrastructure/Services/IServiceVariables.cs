namespace Xde.Software.Infrastructure.Services;

public interface IServiceVariables<TService>
    where TService : IService
{
    EnvironmentVariable[] Variables { get; }
}

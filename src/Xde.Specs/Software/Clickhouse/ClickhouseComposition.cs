using Microsoft.Extensions.DependencyInjection;
using Xde.Software.Composition;
using Xde.Software.Infrastructure.Services;

namespace Xde.Software.Clickhouse;

public class ClickhouseComposition
    : IComposition
{
    /// <inheritdoc />
    void IComposition.Compose(IServiceCollection services)
    {
        // TODO:
        services.AddSingleton<ClickhouseService>();
        services.AddTransient<IServicePorts<ClickhouseService>>(
            provider => provider.GetRequiredService<ClickhouseService>()
        );
        services.AddTransient<IService>(provider => provider.GetRequiredService<ClickhouseService>());
    }
}

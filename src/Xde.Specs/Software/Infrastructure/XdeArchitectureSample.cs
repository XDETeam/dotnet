using Microsoft.Extensions.DependencyInjection;
using Xde.Software.Clickhouse;
using Xde.Software.Composition;
using Xde.Software.Infrastructure.Services;
using Xde.Software.Kafka;

namespace Xde.Software.Infrastructure;

/// <summary>
/// TODO:Sample of XDE infrastructure
/// </summary>
public class XdeArchitectureSample
    : IComposition
{
    public void Compose(IServiceCollection services)
    {
        services.AddSingleton<ClickhouseService>();
        services.AddTransient<IService>(provider => provider.GetRequiredService<ClickhouseService>());

        services.AddSingleton<KafkaService>();
        services.AddTransient<IService>(provider => provider.GetRequiredService<KafkaService>());

        services.AddSingleton<ServiceCatalog>();
    }
}

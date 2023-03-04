using Microsoft.Extensions.DependencyInjection;
using Xde.Software.Clickhouse;
using Xde.Software.Composition;
using Xde.Software.Infrastructure.Services;

namespace Xde.Software.Kubernetes;

public class KubernetesManifestGenerator
{
    /// <summary>
    /// TODO:
    /// </summary>
    /// <param name="architecture"></param>
    /// <returns></returns>
    /// 
    /// <remarks>
    /// TODO: Replace with generation into virtual filesystem
    /// </remarks>
    public string Generate(IComposition composition)
    {
        var services = new ServiceCollection();
        composition.Compose(services);

        var provider = services.BuildServiceProvider();

        var appServices = provider.GetService<IService>();
        var ports = provider.GetService<IServicePorts<ClickhouseService>>();
        var vars = provider.GetService<IServiceVariables<ClickhouseService>>();

        return string.Empty;
    }

    public static string Generate<T>()
        where T : IComposition, new()
    {
        var generator = new KubernetesManifestGenerator();

        var architecture = new T();

        return generator.Generate(architecture);
    }
}

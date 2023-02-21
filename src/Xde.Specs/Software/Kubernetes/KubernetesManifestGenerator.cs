//TODO:
//using Microsoft.Extensions.DependencyInjection;
//using Xde.Software.Clickhouse;
//using Xde.Software.Infrastructure;
//using Xde.Software.Infrastructure.Services;

//namespace Xde.Software.Kubernetes;

//public class KubernetesManifestGenerator
//{
//    /// <summary>
//    /// TODO:
//    /// </summary>
//    /// <param name="architecture"></param>
//    /// <returns></returns>
//    /// 
//    /// <remarks>
//    /// TODO: Replace with generation into virtual filesystem
//    /// </remarks>
//    public string Generate(Architecture architecture)
//    {
//        var provider = architecture.Services.BuildServiceProvider();
//        var services = provider.GetService<IService>();
//        var clickhouse = provider.GetService<ClickhouseService>();

//        return string.Empty;
//    }

//    public static string Generate<T>()
//        where T : Architecture, new()
//    {
//        var generator = new KubernetesManifestGenerator();

//        var architecture = new T();

//        return generator.Generate(architecture);
//    }
//}

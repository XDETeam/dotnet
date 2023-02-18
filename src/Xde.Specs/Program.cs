using System.Reflection;
using Xde.Software.Infrastructure;
using Xde.Software.Kubernetes;

var version = typeof(Program)
    .Assembly
    ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
    ?.InformationalVersion
;

Console.WriteLine($"XDE Spec. Version {version}");

//var commands = typeof(Program)
//    .Assembly
//    .GetExportedTypes()
//    .Where(type => typeof(Command).IsAssignableFrom(type))
//    .ToArray()
//;

Console.WriteLine(KubernetesManifestGenerator.Generate<XdeArchitectureSample>());

return 0;
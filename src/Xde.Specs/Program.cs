using System.Reflection;
using Xde.Software.Infrastructure;
using Xde.Software.Kubernetes;
using Xde.Software.Specs;

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

//Console.WriteLine(KubernetesManifestGenerator.Generate<XdeArchitectureSample>());

SpecsServer.Open("/xml/test");

return 0;
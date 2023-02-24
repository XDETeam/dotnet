using System.Reflection;
using Xde.Software.Specs;
using Xde.Software.Specs.Handlers;

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

SpecsServer.Open(SpecsInfrastructureHandler.RouteName);

return 0;
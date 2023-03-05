using System.Reflection;
using Xde.Software.Infrastructure;
using Xde.Software.Orchestration.Kubernetes;

// TODO:Inject into DI and make startup very simple, compose commands, all composition, etc
// from selected assemblies. So smth like App.Compose<...settings...>().Run();
var version = typeof(Program)
    .Assembly
    ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
    ?.InformationalVersion
;

Console.WriteLine($"XDE Spec. Version {version}");

// TODO:Commands handling //////////////////////////////////////////////////////
//var commands = typeof(Program)
//    .Assembly
//    .GetExportedTypes()
//    .Where(type => typeof(Command).IsAssignableFrom(type))
//    .ToArray()
//;

// TODO:K8s manifests generator ////////////////////////////////////////////////
Console.WriteLine(KubernetesManifestGenerator.Generate<XdeArchitectureSample>());

// TODO:Specs server experiments ///////////////////////////////////////////////
// SpecsServer.Open(SpecsInfrastructureHandler.RouteName);

// TODO:Benchmarking ///////////////////////////////////////////////////////////
//var summary = TestBenchmark.Run();
//Console.WriteLine(summary);

//return 0;
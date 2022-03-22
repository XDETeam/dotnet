using System.Reflection;

var version = typeof(Program)
    .Assembly
    ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
    ?.InformationalVersion
;

Console.WriteLine($"XDE Spec. Version {version}");

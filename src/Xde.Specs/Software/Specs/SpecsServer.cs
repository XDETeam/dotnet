using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xde.Software.Clickhouse;
using Xde.Software.Infrastructure;
using Xde.Software.Infrastructure.Services;

namespace Xde.Software.Specs;

public class SpecsServer
{
    private readonly WebApplicationBuilder _builder;
    private readonly WebApplication _app;

    public void Run(bool openBrowser = true, string? path = null)
    {
        _app.StartAsync();

        var serverAddress = _app
            .Services
            .GetService<IServerAddressesFeature>()
            ?.Addresses.First()
            ?? "http://localhost:5000"
        ;

        //TODO:Take the real URL from the server
        if (serverAddress != null && openBrowser)
        {
            var uri = new Uri(new Uri(serverAddress), path);

            Process.Start(new ProcessStartInfo
            {
                FileName = uri.ToString(),
                UseShellExecute = true
            });
        }

        _app.WaitForShutdown();
    }

    public SpecsServer()
    {
        _builder = WebApplication
            .CreateBuilder()
        ;

        var architecture = new XdeArchitectureSample();
        architecture.Compose(_builder.Services);

        _app = _builder.Build();

        // TODO:This value and calculation is already used in CLI, so would be better
        // to share environment. Probably through CLI commands in DI.
        var version = typeof(Program)
            .Assembly
            ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion
        ;

        _app.MapGet("/", () => $"XDE Spec. Version {version}");
        _app.MapGet(
            "/infrastructure/{path}",
            async (
                HttpContext context,
                string path,
                ServiceCatalog services,
                [FromServices]ClickhouseService clickhouse
            ) => {

                await context.Response.WriteAsync($"XML: {services}!");
            }
        );
    }

    public async static void Open(string? path = null) => new SpecsServer().Run(path: path);
}

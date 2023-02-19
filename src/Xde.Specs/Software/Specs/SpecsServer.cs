using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Xde.Software.Specs;

public class SpecsServer
{
    private readonly WebApplicationBuilder _builder;
    private readonly WebApplication _app;

    public void Run(bool openBrowser = true)
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
            Process.Start(new ProcessStartInfo
            {
                FileName = serverAddress,
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

        _app = _builder.Build();

        _app.MapGet("/", () => "Hello World!");
    }

    public async static void Open() => new SpecsServer().Run();
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Xde.Software.Infrastructure.Services;

namespace Xde.Software.Specs.Handlers;

public class SpecsInfrastructureHandler
    : ISpecsRouteHandler
{

    public const string RouteName = "/infrastructure";

    string ISpecsRouteHandler.Route => RouteName;

    async private Task OnGet(HttpContext context, ServiceCatalog services)
    {
        //TODO:
        await context.Response.WriteAsync($"SpecsInfrastructureHandler: {services}!");
    }

    void ISpecsRouteHandler.Register(WebApplication application)
    {
        application.MapGet(RouteName, OnGet);
    }
}

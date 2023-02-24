using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Xde.Software.Infrastructure.Services;

namespace Xde.Software.Specs.Handlers;

public class SpecsInfrastructureHandler
    : ISpecsRouteHandler
{

    public const string RouteName = "/infrastructure";

    //TODO:Add shared namespace, etc
    public static readonly XName XmlInfrastructure = XName.Get("infrastructure");
    public static readonly XName XmlService = XName.Get("service");

    string ISpecsRouteHandler.Route => RouteName;

    async private Task OnGet(HttpContext context, ServiceCatalog catalog)
    {
        var xml = new XDocument(
            new XElement(
                XmlInfrastructure,
                catalog.Services
                    .Select(service => new XElement(
                        XmlService,
                        new XText(service.ToString())
                    ))
            )
        );

        await context.Response.WriteAsync(xml.ToString());
    }

    void ISpecsRouteHandler.Register(WebApplication application)
    {
        application.MapGet(RouteName, OnGet);
    }
}

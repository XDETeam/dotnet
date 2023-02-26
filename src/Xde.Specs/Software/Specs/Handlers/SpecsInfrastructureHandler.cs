using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Xde.Software.Infrastructure.Services;
using Xde.Software.Specs.Styles;

namespace Xde.Software.Specs.Handlers;

public class SpecsInfrastructureHandler
    : ISpecsRouteHandler
{

    public const string RouteName = "/infrastructure";

    //TODO:Add shared namespace, etc
    public static readonly XName XmlInfrastructure = XName.Get("infrastructure");
    public static readonly XName XmlService = XName.Get("service");

    private readonly IXslStyleProvider _styleProvider;

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

        //TODO:Shortcut the resource path, maybe using type or some prefix/extension/resource interface
        var xslt = _styleProvider.Get("main");

        var args = new XsltArgumentList();

        //TODO:Sync version does not work well
        //TODO:Notices that in some callstacks "System.Xml.Xsl.XsltOld" mentioned. Probably there are new :)
        //var writer = XmlWriter.Create(context.Response.Body);
        //xslt.Transform(xml.ToXPathNavigable(), args, context.Response.Body);
        var builder = new StringBuilder();
        var writer = XmlWriter.Create(builder);
        xslt.Transform(xml.ToXPathNavigable(), args, writer);

        var response = Results.Content(builder.ToString());

        context.Response.ContentType = "text/html";

        await context.Response.WriteAsync(builder.ToString());
    }

    void ISpecsRouteHandler.Register(WebApplication application)
    {
        application.MapGet(RouteName, OnGet);
    }

    public SpecsInfrastructureHandler(IXslStyleProvider styleProvider)
    {
        _styleProvider = styleProvider;
    }
}

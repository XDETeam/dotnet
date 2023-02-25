using System.Net.Http.Headers;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;
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

        // TODO:Exctract (ISpecsRouteHandler) and cache. Maybe cache XslCompiledTransform.
        var test1 = GetType().Assembly.GetManifestResourceNames();
        //TODO:Shortcut the resource path, maybe using type or some prefix/extension/resource interface
        using var stream = GetType().Assembly.GetManifestResourceStream("Xde.Software.Specs.Styles.main.xslt");
        using var reader = XmlReader.Create(stream);

        //TODO:var xslt = new XslTransform();
        var xslt = new XslCompiledTransform(); //TODO:Debug option can be enabled
        xslt.Load(reader);

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
}

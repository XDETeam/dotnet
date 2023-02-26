using System.Xml;
using System.Xml.Xsl;
using Microsoft.Extensions.Caching.Memory;

namespace Xde.Software.Specs.Styles;

public class XslStyleProvider
    : IXslStyleProvider
{
    private readonly IMemoryCache _cache;

    XslCompiledTransform IXslStyleProvider.Get(string styleName) => _cache.GetOrCreate(styleName, entry =>
    {
        using var stream = GetType().Assembly.GetManifestResourceStream($"{ResourcePrefix}.{styleName}.xslt");
        using var reader = XmlReader.Create(stream);
            
        var xslt = new XslCompiledTransform(); //TODO:Debug option can be enabled
        xslt.Load(reader);

        return xslt;
    });

    public XslStyleProvider(IMemoryCache cache)
    {
        _cache = cache;
    }

    //TODO:Can be calculated
    public const string ResourcePrefix = "Xde.Software.Specs.Styles";
}

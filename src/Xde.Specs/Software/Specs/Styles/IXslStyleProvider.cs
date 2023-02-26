using System.Xml.Xsl;

namespace Xde.Software.Specs.Styles;

public interface IXslStyleProvider
{
    XslCompiledTransform Get(string styleName);
}

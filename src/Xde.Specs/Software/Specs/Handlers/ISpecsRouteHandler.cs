using Microsoft.AspNetCore.Builder;

namespace Xde.Software.Specs.Handlers;

/// <summary>
/// Specs route handler
/// </summary>
/// 
/// <remarks>
/// TODO:Basic handler for internal specs web-server.
/// </remarks>
public interface ISpecsRouteHandler
{
    string Route { get; }

    void Register(WebApplication application);
}

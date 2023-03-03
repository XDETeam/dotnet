using Microsoft.Extensions.DependencyInjection;

namespace Xde.Software.Composition;

public static class IServiceCollectionExtensions
{
    public static void Compose<TComposition>(this IServiceCollection services)
        where TComposition : IComposition, new()
    {
        new TComposition().Compose(services);
    }
}

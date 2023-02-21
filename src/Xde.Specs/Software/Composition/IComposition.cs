using Microsoft.Extensions.DependencyInjection;

namespace Xde.Software.Composition;

public interface IComposition
{
    void Compose(IServiceCollection services);
}

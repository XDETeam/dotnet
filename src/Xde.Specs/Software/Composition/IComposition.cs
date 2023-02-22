using Microsoft.Extensions.DependencyInjection;

namespace Xde.Software.Composition;

public interface IComposition
{
    // TODO:
    // Should not depend on Microsoft.Extensions.DependencyInjection?
    // It's limited, e.g. for registering multiple interfaces for a singleton
    // a workaround should be applied.
    void Compose(IServiceCollection services);
}

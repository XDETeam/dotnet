using Microsoft.Extensions.DependencyInjection;
using Xde.Software.Infrastructure.Services;

namespace Xde.Software.Infrastructure;

public abstract class Architecture
{
    public ServiceCollection Services { get; } = new ServiceCollection();

    public void Add<T>()
        where T : class, IService
    {
        Services.AddSingleton<T>();
    }

    public abstract void Define();
}

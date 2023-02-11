using Xde.Software.Infrastructure.Services;

namespace Xde.Software.Infrastructure;

public class Infrastructure
{
    public ICollection<IService> Services { get; } = new List<IService>();
}

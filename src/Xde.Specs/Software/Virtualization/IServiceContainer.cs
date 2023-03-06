namespace Xde.Software.Virtualization;

public interface IServiceContainer<TService>
{
    string Image { get; }

    string Version { get; }
}

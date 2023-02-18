using Xde.Software.Clickhouse;
using Xde.Software.Kafka;

namespace Xde.Software.Infrastructure;

/// <summary>
/// TODO:Sample of XDE infrastructure
/// </summary>
public class XdeArchitectureSample
    : Architecture
{
    public XdeArchitectureSample()
    {
        Add<ClickhouseService>();
        Add<KafkaService>();
    }
}

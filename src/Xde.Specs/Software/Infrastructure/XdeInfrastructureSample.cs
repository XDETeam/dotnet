using Xde.Software.Clickhouse;
using Xde.Software.Kafka;

namespace Xde.Software.Infrastructure;

/// <summary>
/// TODO:Sample of XDE infrastructure
/// </summary>
public class XdeInfrastructureSample
    : Infrastructure
{
    public ClickhouseService Clickhouse { get; } = new ClickhouseService();

    public KafkaService Kafka { get; } = new KafkaService();

    public void Define()
    {
        Services.Add(Clickhouse);
        Services.Add(Kafka);
    }
}

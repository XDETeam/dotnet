using Xde.Software.Infrastructure.Services;

namespace Xde.Software.Clickhouse;

public class ClickhouseService
    : IService
{
    public const string Description = "Clickhouse database server";

    public static readonly ServicePort[] Ports =
    {
        new(8123, "http", "HTTP API Port for http requests. used by JDBC, ODBC and web interfaces."),
        new(9000, "native", "Native Protocol port (also referred to as ClickHouse TCP protocol). Used by ClickHouse apps."),
        new(9181, "keeper", "Recommended ClickHouse Keeper port"),
        new(9234, "keeper-raft", "Recommended ClickHouse Keeper Raft port"),
        new(9281, "keeper-secure", "Recommended Secure SSL ClickHouse Keeper port")
    };

    //TODO:
    public static readonly EnvironmentVariable[] EnvVars =
    {
        new("CLICKHOUSE_DB", "main"), //TODO:Do we need a database
        new("CLICKHOUSE_USER", "main"),
        new("CLICKHOUSE_PASSWORD", "clickhouse-test-password"),
    };

    public const string DockerImage = "docker.io/clickhouse/clickhouse-server";
}

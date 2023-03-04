using Xde.Software.Infrastructure.Services;

namespace Xde.Software.Clickhouse;

public class ClickhouseService
    : IService
    , IServicePorts<ClickhouseService>
    , IServiceVariables<ClickhouseService>
{
    public const string Description = "Clickhouse database server";

    public const string DockerImage = "docker.io/clickhouse/clickhouse-server";

    //TODO:public ClickhouseService(IDeploymentConfiguration configuration)
    //public ClickhouseService(IConfiguration configuration)

    #region -- IServiceVariables<ClickhouseService> implementation -------------
    private static readonly EnvironmentVariable[] _vars =
    {
        new("CLICKHOUSE_DB", "main"), //TODO:Do we need a database
        new("CLICKHOUSE_USER", "main"),
        new("CLICKHOUSE_PASSWORD", "clickhouse-test-password"),
    };

    EnvironmentVariable[] IServiceVariables<ClickhouseService>.Variables => _vars;
    #endregion -----------------------------------------------------------------

    #region -- IServicePorts<ClickhouseService> implementation -----------------
    private static readonly ServicePort[] _ports =
    {
        new(8123, "http", "HTTP API Port for http requests. used by JDBC, ODBC and web interfaces."),
        new(9000, "native", "Native Protocol port (also referred to as ClickHouse TCP protocol). Used by ClickHouse apps."),
        new(9181, "keeper", "Recommended ClickHouse Keeper port"),
        new(9234, "keeper-raft", "Recommended ClickHouse Keeper Raft port"),
        new(9281, "keeper-secure", "Recommended Secure SSL ClickHouse Keeper port")
    };

    /// <inheritdoc />
    ServicePort[] IServicePorts<ClickhouseService>.Ports => _ports;
    #endregion -----------------------------------------------------------------
}

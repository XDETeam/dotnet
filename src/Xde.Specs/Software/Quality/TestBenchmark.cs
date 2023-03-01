using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using ClickHouse.Client.ADO;
using ClickHouse.Client.Utility;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace Xde.Software.Quality;

/// <summary>
/// TODO:Experimental Clickhouse benchmark
/// </summary>
[InProcess]
public class TestBenchmark
{
    private DockerClientConfiguration _config;
    private DockerClient _docker;
    private CreateContainerResponse _clickhouse;

    public static Summary Run() => BenchmarkRunner.Run<TestBenchmark>(
        ManualConfig
        .Create(DefaultConfig.Instance)
        .WithOptions(ConfigOptions.DisableOptimizationsValidator)
    );

    private async Task<ClickHouseConnection> InitConnection()
    {
        var connection = new ClickHouseConnection("Host=localhost;Port=18123");
        await connection.OpenAsync();

        return connection;
    }

    [Benchmark(Baseline = true)]
    public async ValueTask<byte> TestConstant()
    {
        using var connection = await InitConnection();
        var result = await connection.ExecuteScalarAsync("select 1");
        return (byte)result;
    }

    [Benchmark]
    public async ValueTask<ushort> TestExpression()
    {
        using var connection = await InitConnection();
        var result = await connection.ExecuteScalarAsync("select 12+34");
        return (ushort)result;
    }

    [Benchmark]
    public async ValueTask<ulong> TestScalarQuery()
    {
        using var connection = await InitConnection();
        var result = await connection.ExecuteScalarAsync("select count(*) from system.tables");
        return (ulong)result;
    }

    [GlobalSetup]
    public async Task GlobalSetup()
    {
        _config = new DockerClientConfiguration();
        _docker = _config.CreateClient();
        _clickhouse = await _docker.Containers.CreateContainerAsync(new CreateContainerParameters
        {
            Name = "xde-temp-clickhouse-bench",
            Image = "docker.io/clickhouse/clickhouse-server",
            ExposedPorts = new Dictionary<string, EmptyStruct>
    {
        { "8123", default },
        { "9000", default }
    },
            HostConfig = new()
            {
                PortBindings = new Dictionary<string, IList<PortBinding>>()
        {
            {"8123", new List<PortBinding> {new PortBinding { HostPort = "18123" } }},
            {"9000", new List<PortBinding> {new PortBinding { HostPort = "19000" } }}
        },
                PublishAllPorts = true
            }
        });

        var started = await _docker.Containers.StartContainerAsync(_clickhouse.ID, new ContainerStartParameters());
        if (!started)
        {
            throw new ApplicationException();
        }
    }

    [GlobalCleanup]
    public async Task GlobalCleanup()
    {
        await _docker.Containers.RemoveContainerAsync(_clickhouse.ID, new ContainerRemoveParameters
        {
            Force = true,
            RemoveVolumes = true
        });

        _docker.Dispose();
    }
}

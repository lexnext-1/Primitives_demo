using BenchmarkDotNet.Attributes;
using Primitives.Common.Clients;
using Primitives.Common.Servers.Primitives;

namespace Primitives.Benchmark.Benchmarks;


[MemoryDiagnoser]
[RankColumn]
public class PrimitivesBenchmark
{

    private  int _countOfParalles;
    private  int _countInArray; 
  
    
    
    [GlobalSetup]
    public void Setup()
    {
        _countInArray = 2000;
        _countOfParalles = 10;
    }
        
    [Benchmark]

    public async Task  Semaphore()
    {
        var semaphoreServer = new MonitorServer();
        var semaphoreClient = new PararallelClient(semaphoreServer, _countOfParalles, _countInArray);
        await semaphoreClient.SendValues();
    }
    
    [Benchmark]
    public async Task Monitor()
    {
        var monitorServer = new MonitorServer();
        var monitorClient = new PararallelClient(monitorServer, _countOfParalles, _countInArray);
        await monitorClient.SendValues();
    }
    
    
    [Benchmark]
    public async Task SpinLock()
    {
        var server = new SpinLockServer();
        var client = new PararallelClient(server, _countOfParalles, _countInArray);
        await client.SendValues();
    }
    
    
 
}
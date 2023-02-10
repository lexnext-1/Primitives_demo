using BenchmarkDotNet.Attributes;
using Primitives.Common.Clients;
using Primitives.Common.Servers.Primitives;

namespace Primitives.Benchmark.Benchmarks;


[MemoryDiagnoser]
[RankColumn]
public class PrimitivesBenchmark
{

    [Params(10,20)]
    public  int CountOfParalles;
    [Params(1000,2000)]
    public  int CountInArray; 
  
    
    
    [GlobalSetup]
    public void Setup()
    {
   
    }
        
    [Benchmark]

    public async Task  Semaphore()
    {
        var semaphoreServer = new MonitorServer();
        var semaphoreClient = new PararallelClient(semaphoreServer, CountOfParalles, CountInArray);
        await semaphoreClient.SendValues();
    }
    
    [Benchmark]
    public async Task Monitor()
    {
        var monitorServer = new MonitorServer();
        var monitorClient = new PararallelClient(monitorServer, CountOfParalles, CountInArray);
        await monitorClient.SendValues();
    }
    
    
    [Benchmark]
    public async Task SpinLock()
    {
        var server = new SpinLockServer();
        var client = new PararallelClient(server, CountOfParalles, CountInArray);
        await client.SendValues();
    }
    
    
 
}
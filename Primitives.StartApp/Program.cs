
using Primitives.Common.Clients;
using Primitives.Common.Servers;
using Primitives.Common.Servers.Primitives;

// var semaphoreServer = new SemaphoreSlimServer();
// var semaphoreClient = new PararallelClient(semaphoreServer);
// semaphoreClient.SendValues().Wait();
//
// var resultSemaphore = await semaphoreServer.GetAllData();
//
// Console.WriteLine($"Semaphore count: {resultSemaphore.Count()}");

//await  ExecuteClient(new SemaphoreSlimServer());
//await  ExecuteClient(new MonitorServer());
await  ExecuteClient(new SpinLockServer());


async Task ExecuteClient(ICacheServerPrimitive serverPrimitive)
{
   
    var client = new PararallelClient(serverPrimitive, 6, 100);
    await client.SendValues();


    var result = await serverPrimitive.GetAllData();

    Console.WriteLine($"{serverPrimitive.GetType()}: {result.Count()}");
}
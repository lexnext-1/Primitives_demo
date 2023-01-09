using Primitives.Common.Models;
using Primitives.Common.Servers;

namespace Primitives.Common.Clients;

public class PararallelClient : BaseCacheClient, ICacheClient
{
    private readonly ICacheServerPrimitive _cacheServer;

    public PararallelClient(ICacheServerPrimitive cacheServer, int countParallels, int countInArray)
    {
        _cacheServer = cacheServer;
        CountOfParalles = countParallels;
        CountInArray = countInArray;
    }

    public  async Task SendValues()
    {
    
        // 
        var data = await InitDataset_90Percent();

        var tokenActual = CancellationToken.None;

        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = CountOfParalles,
        };


        Parallel.ForEach(data, options, async (item, token) =>
        {

            // Console.WriteLine($"Element of array:  {Task.CurrentId} - {Thread.CurrentThread.ManagedThreadId}");
            var taskNested = new List<Task>();
            foreach (var model in item)
            {
                var task = Task.Run(() => _cacheServer.AddData(model), tokenActual);
                taskNested.Add(task);
            }

            Task.WaitAll(taskNested.ToArray());
        });
    }

    public Task GetValue(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CacheModel>> GetValues()
    {
        throw new NotImplementedException();
    }


}
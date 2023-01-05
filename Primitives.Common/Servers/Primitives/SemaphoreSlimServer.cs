using Primitives.Common.Models;

namespace Primitives.Common.Servers.Primitives;

public class SemaphoreSlimServer : BaseCacheServer, ICacheServerPrimitive
{
    private readonly SemaphoreSlim _semaphore = new(1);

    public async Task AddData(CacheModel model)
    {
        await _semaphore.WaitAsync();


         await NoSafetyAddData(model);


        _semaphore.Release();
    }
}
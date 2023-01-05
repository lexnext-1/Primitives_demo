using Primitives.Common.Models;

namespace Primitives.Common.Servers.Primitives;

public class SpinLockServer : BaseCacheServer, ICacheServerPrimitive
{
    private SpinLock _spinlock = new();
    public Task AddData(CacheModel model)
    {
        bool isLocked = false;
        try
        {
            _spinlock.Enter(ref isLocked);
             NoSafetyAddData(model).Wait();
        }
        finally
        {
            if (isLocked) _spinlock.Exit(false);
            
        }
        return Task.CompletedTask;
    }
}
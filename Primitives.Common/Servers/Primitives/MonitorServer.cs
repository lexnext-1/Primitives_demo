using Primitives.Common.Models;

namespace Primitives.Common.Servers.Primitives;

public class MonitorServer : BaseCacheServer, ICacheServerPrimitive
{
    
    private  object _syncObject = new();
    private  bool _wasTakedLock = false;
    
    public Task AddData(CacheModel model)
    {
        Monitor.Enter(_syncObject);
        try
        {
          
            NoSafetyAddData(model);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"MonitorServer: {ex.Message} Data: {model.Id}");
        }
        finally
        {
          //  if (_wasTakedLock)
                Monitor.Exit(_syncObject);
        }

        return Task.CompletedTask;
    }
}
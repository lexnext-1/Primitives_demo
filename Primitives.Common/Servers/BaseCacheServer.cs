using System.Diagnostics;
using Primitives.Common.Models;

namespace Primitives.Common.Servers;

public abstract class BaseCacheServer 
{
    protected List<CacheModel> Data = new ();




    public virtual async Task<IEnumerable<CacheModel>> GetAllData()
        =>  await Task.FromResult<IEnumerable<CacheModel>>(Data);
    
    
    public virtual async Task<bool> NoSafetyAddData(CacheModel model)
    {
        if (Data.All(p => p.Id != model.Id))
        {
            Data.Add(model);
            return await Task.FromResult(true);
        }

        return await Task.FromResult(false);
    }
}
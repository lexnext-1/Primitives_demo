using Primitives.Common.Models;

namespace Primitives.Common.Clients;

public abstract class BaseCacheClient 
{

    protected int CountOfParalles { get; init; }
    protected  int CountInArray  { get; init; }
    
    
 

    protected virtual async Task<CacheModel[][]> InitDataset_Half()
    {
        CacheModel[][] dataSet = new CacheModel[CountOfParalles][];

        for (var i = 0; i < CountOfParalles; i++)
        {
            var temp = i == 0
                ? Enumerable.Range(0, CountInArray).ToArray()
                : Enumerable.Range(CountInArray * i - CountInArray / 2, CountInArray).ToArray();
            dataSet[i] = temp.ToList().Select(p=>new CacheModel(){Id=p}).ToArray();
        }

        return await Task.FromResult(dataSet);
    }
    
    protected virtual async Task<CacheModel[][]> InitDataset_10Percent()
    {
        CacheModel[][] dataSet = new CacheModel[CountOfParalles][];

        for (var i = 0; i < CountOfParalles; i++)
        {
            var temp = i == 0
                ? Enumerable.Range(0, CountInArray).ToArray()
                : Enumerable.Range(CountInArray * i - CountInArray / 10, CountInArray).ToArray();
            dataSet[i] = temp.ToList().Select(p=>new CacheModel(){Id=p}).ToArray();
        }

        return await Task.FromResult(dataSet);
    }
}
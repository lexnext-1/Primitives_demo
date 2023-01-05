using Primitives.Common.Models;

namespace Primitives.Common.Servers;

public interface ICacheServerPrimitive
{
    Task AddData(CacheModel model);

    Task<IEnumerable<CacheModel>> GetAllData();

}
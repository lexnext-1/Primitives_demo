using Primitives.Common.Models;

namespace Primitives.Common.Clients;

public interface ICacheClient
{
    Task SendValues();
    
    Task GetValue(int id);

    Task<IEnumerable<CacheModel>> GetValues();

}
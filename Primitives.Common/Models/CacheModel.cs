namespace Primitives.Common.Models;

public class CacheModel
{
    public int Id { get; set; }

    /// <summary>
    /// as stub
    /// </summary>
    public string Value { get; set; } = Guid.NewGuid().ToString();
}
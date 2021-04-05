using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoCorp.Triangles.App
{
  public class LocalUniqueRepository<T> : IRepository<T>
  {
    readonly HashSet<T> collection = new();

    public ValueTask<bool> AddAsync(T item)
    {
      return new(collection.Add(item));
    }

    public ValueTask<int> CountAsync()
    {
      return new(collection.Count);
    }
  }
}

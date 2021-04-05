using System.Threading.Tasks;

namespace DemoCorp.Triangles.App
{
  public interface IRepository<T>
  {
    ValueTask<bool> AddAsync(T item);
    ValueTask<int> CountAsync();
  }
}

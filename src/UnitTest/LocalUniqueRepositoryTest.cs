using DemoCorp.Triangles.App;
using DemoCorp.Triangles.Data;
using Xunit;

namespace DemoCorp.Triangles.UnitTest
{
  public class LocalUniqueRepositoryTest
  {
    [Fact]
    public void Count_TwoDifferentTriangles_BothIsStored()
    {
      var sut = new LocalUniqueRepository<Triangle>();
      Triangle.TryParse(4, 5, 6, out var tri1);
      sut.AddAsync(tri1);
      Triangle.TryParse(3, 4, 5, out var tri2);
      sut.AddAsync(tri2);
      Assert.Equal(2, sut.CountAsync().Result);
    }

    [Fact]
    public void Count_TwoEqualTriangles_OnlyOneStored()
    {
      var sut = new LocalUniqueRepository<Triangle>();
      Triangle.TryParse(3, 4, 5, out var tri1);
      sut.AddAsync(tri1);
      Triangle.TryParse(3, 4, 5, out var tri2);
      sut.AddAsync(tri2);
      Assert.Equal(1, sut.CountAsync().Result);
    }
  }
}

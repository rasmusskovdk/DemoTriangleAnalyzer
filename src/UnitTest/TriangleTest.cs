using DemoCorp.Triangles.Data;
using Xunit;

namespace DemoCorp.Triangles.UnitTest
{
  public class TriangleTest
  {
    [Theory]
    [InlineData(3, 4, 5, TriangleFeatures.Scalene)]
    [InlineData(1, 2, 2, TriangleFeatures.Isosceles)]
    [InlineData(1, 1, 1, TriangleFeatures.Equilateral | TriangleFeatures.Isosceles)]
    public void TryParse_Triangle_FeaturesMatch(int x, int y, int z, TriangleFeatures expectedFeatures)
    {
      Assert.True(Triangle.TryParse(x, y, z, out var triangle));
      Assert.Equal(expectedFeatures, triangle.Features);
    }

    [Theory]
    [InlineData(3, 4, 0)]
    [InlineData(3, 4, -5)]
    [InlineData(3, 4, 15)]
    public void TryParse_NotTriangle_DoesNotParse(int x, int y, int z)
    {
      Assert.False(Triangle.TryParse(x, y, z, out var triangle));
    }
  }
}

using System;
using System.Linq;

namespace DemoCorp.Triangles.Data
{
  public record Triangle
  {
    private readonly int a;
    private readonly int b;
    private readonly int c;
    public readonly TriangleFeatures Features;

    private Triangle(int x, int y, int z)
    {
      Array.Sort(new[]{x, y, z});
      a = z;
      b = y;
      c = x;

      if (a == b || a == c || b == c)
      {
        Features = TriangleFeatures.Isosceles;
        if (a == b && b == c)
          Features |= TriangleFeatures.Equilateral;
      }
      else
        Features = TriangleFeatures.Scalene;
    }

    public static bool TryParse(int a, int b, int c, out Triangle triangle)
    {
      triangle = null;
      if(a+b<=c || a+c<=b || b+c<=a)
        return false;
      triangle = new Triangle(a,b,c);
      return true;
    }
  }

  [Flags]
  public enum TriangleFeatures
  {
    Scalene = 0,
    Equilateral = 1,
    Isosceles = 2,
  }
}

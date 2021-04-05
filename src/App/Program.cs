using System;
using System.Net;
using System.Threading.Tasks;
using DemoCorp.Triangles.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCorp.Triangles.App
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var serviceProvider = new ServiceCollection()
        .AddSingleton<IRepository<Triangle>, LocalUniqueRepository<Triangle>>()
        .BuildServiceProvider();

      var repo = serviceProvider.GetService<IRepository<Triangle>>();

      while (true)
      {
        int a, b, c;
        Console.WriteLine("Creating triangles, with integer side lengths");
        try
        {
          Console.Write("First side:");
          a = Int32.Parse(Console.ReadLine()!);
          Console.Write("Second side:");
          b = Int32.Parse(Console.ReadLine());
          Console.Write("Third side:");
          c = Int32.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
          Console.Error.WriteLine("Only integer side lengths is allowed.");
          throw;
        }
        if (Triangle.TryParse(a, b, c, out var triangle))
        {
          Console.WriteLine($"\nYour triangle is: {triangle.Features}");
          var added = await repo.AddAsync(triangle);
          Console.WriteLine($"Your triangle was {(added ? "added to" : "already present in")} repository. Total count: {await repo.CountAsync()}");
        }
        else
          Console.WriteLine($"This was not a triangle, try again...");
      }
    }
  }
}

using System;
using System.Diagnostics;
using System.Threading;

namespace PostSharp.Samples.CustomCaching
{
  internal class Program
  {
    private static readonly Stopwatch stopwatch = Stopwatch.StartNew();

    private static void Main(string[] args)
    {
      // First call of the cached methods. At this point, the cache is empty and execution will be slow.
      WriteMessage(Hello("world"));
      WriteMessage(Hello("universe"));

      // Second call of the cached method. The results are already cache
      WriteMessage(Hello("world"));
      WriteMessage(Hello("universe"));
    }

    // Write a message to the console with a timestamp.
    private static void WriteMessage(string message)
    {
      Console.WriteLine("{0} ms - {1}", stopwatch.ElapsedMilliseconds, message);
    }

    [Cache]
    private static string Hello(string who)
    {
      // Write something to the console and wait to show that the method is actually being executed.
      WriteMessage(string.Format("Doing complex stuff for {0}.", who));
      Thread.Sleep(500);


      return string.Format("Hello, {0}", who);
    }
  }
}
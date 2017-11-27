using System;
using System.Threading.Tasks;
using PostSharp.Patterns.Threading;

namespace PostSharp.Samples.Threading.PingPong
{
  [Actor]
  internal class ConsoleLogger
  {
    [Reentrant]
    public async void WriteLine(string message, ConsoleColor color = ConsoleColor.White)
    {
      Console.ForegroundColor = color;
      Console.WriteLine(message);
    }

    [Reentrant]
    public async Task Flush()
    {
    }
  }
}
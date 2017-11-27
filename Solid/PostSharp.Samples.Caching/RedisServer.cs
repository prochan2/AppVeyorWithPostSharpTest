using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PostSharp.Samples.Caching
{
  internal class RedisServer : IDisposable
  {
    private Process process;

    private RedisServer(Process process)
    {
      this.process = process;
    }


    public void Dispose()
    {
      if (process != null)
      {
        Console.WriteLine("Stopping Redis server.");
        process.Close();
        process = null;
      }
    }

    public static RedisServer Start()
    {
      if (!Process.GetProcessesByName("redis-server").Any())
      {
        var configFile = Path.GetFullPath("redis.conf");

        Console.WriteLine("Starting Redis server with config file: " + configFile);

        return new RedisServer(Process.Start(@"..\..\..\..\packages\redis-64.3.0.503\tools\redis-server.exe",
          configFile));
      }
      return new RedisServer(null);
    }
  }
}
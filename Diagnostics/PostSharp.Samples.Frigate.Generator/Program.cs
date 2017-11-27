using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Frigate;
using PostSharp.Patterns.Diagnostics.ThreadingInstrumentation;

[assembly: ThreadingInstrumentationPolicy]

namespace PostSharp.Frigate.TestProgram
{
  internal class Program
  {
    private const string fileName = "test.flog";
    private static readonly Logger logger;

    [Log(AttributeExclude = true)]
    static Program()
    {
      if (File.Exists(fileName))
        File.Delete(fileName);

      LoggingServices.DefaultBackend = new FrigateLoggingBackend(fileName);
      logger = Logger.GetLogger("Custom", typeof(Logger));
    }

    [Log]
    private static void Main(string[] args)
    {
      logger.Write(LogLevel.Info, "Hello, world! Welcome to the demo log generation app for Frigate.");
      logger.Write(LogLevel.Warning, "This is a warning.");
      logger.Write(LogLevel.Error, "This is an error.");

      var stopwatch = Stopwatch.StartNew();
      Fibonacci(20);

      var count = Environment.ProcessorCount / 2;

      Console.WriteLine($"Generating the log file {fileName} using {count} cores...");


      var tasks = new Task[count];
      for (var i = 0; i < count; i++)
        tasks[i] = Task.Run(() => MakeOneMillionCalls());


      Task.WhenAll(tasks).Wait();

      Console.WriteLine(
        $"Generated 11M records in in {stopwatch.Elapsed}. This is ~{1E3 * 11 / stopwatch.Elapsed.TotalSeconds:0}K records per second/core.");


      try
      {
        ThrowsException(5);
      }
      catch (Exception e)
      {
        logger.WriteException(LogLevel.Warning, e, "Look mom! I handled an exception.");
      }

      // TODO: Instrumentation of Task.Wait will be automatic.
      ReadUrls("http://www.nasa.gov/images/content/178493main_sig07-009-hires.jpg",
          "http://tse2.mm.bing.net/th?id=OIP.Ma1c2cdaa5ded4fd36cd7884605f53471o0&pid=15.1",
          "https://www.postsharp.net/")
        .Wait();
    }

    [Log]
    private static void ThrowsException(int level)
    {
      if (level < 0)
        throw new ArgumentException();

      ThrowsException(level - 1);
    }

    [Log]
    private static int Fibonacci(int n)
    {
      if (n < 0)
        throw new ArgumentOutOfRangeException();
      if (n == 0)
        return 0;
      if (n == 1)
        return 1;

      return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    [Log]
    private static void MakeOneMillionCalls()
    {
      for (var i = 0; i < 1000000; i++)
        MakeTenCalls();
    }

    [Log]
    private static void MakeTenCalls()
    {
      for (var i = 0; i < 10; i++)
        Oops();
    }

    [Log]
    private static void Oops()
    {
    }

    [Log]
    private static async Task ReadUrls(params string[] urls)
    {
      var tasks = new Task[urls.Length];

      for (var i = 0; i < urls.Length; i++)
        tasks[i] = ReadAndHashAsync(urls[i]);

      await Task.WhenAll(tasks);
    }

    [Log]
    private static async Task<byte[]> ReadAndHashAsync(string url)
    {
      var hashAlgorithm = HashAlgorithm.Create("SHA256");
      hashAlgorithm.Initialize();

      var webClient = new WebClient();
      var buffer = new byte[16 * 1024];

      logger.Write(LogLevel.Info, "Working with a {BufferSize}-byte buffer.", buffer.Length);

      using (var stream = webClient.OpenRead(url))
      {
        int countRead;
        while ((countRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
        {
          logger.Write(LogLevel.Info, "Got {CountRead} bytes.", countRead);

          hashAlgorithm.ComputeHash(buffer, 0, countRead);
        }
      }

      logger.Write(LogLevel.Info, "Done!");

      return hashAlgorithm.Hash;
    }
  }
}
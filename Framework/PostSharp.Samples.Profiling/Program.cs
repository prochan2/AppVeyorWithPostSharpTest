using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace PostSharp.Samples.Profiling
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      GetRandomBytes();
      SleepSync();
      SleepAsync().GetAwaiter().GetResult();
      ReadAndHashSync();
      ReadAndHashAsync().GetAwaiter().GetResult();
    }

    [Profile]
    private static void SleepSync()
    {
      Thread.Sleep(200);
    }

    [Profile]
    private static async Task SleepAsync()
    {
      await Task.Delay(200);
    }

    [Profile]
    private static void GetRandomBytes()
    {
      for (var i = 0; i < 100; i++)
      {
        var generator = RandomNumberGenerator.Create();
        var randomBytes = new byte[32 * 1024 * 1024];
        generator.GetBytes(randomBytes);
      }
    }

    [Profile]
    private static void ReadAndHashSync()
    {
      var hashAlgorithm = HashAlgorithm.Create("SHA256");
      hashAlgorithm.Initialize();

      var webClient = new WebClient();
      var buffer = new byte[16 * 1024];
      using (var stream = webClient.OpenRead("http://www.nasa.gov/images/content/178493main_sig07-009-hires.jpg"))
      {
        int countRead;
        while ((countRead = stream.Read(buffer, 0, buffer.Length)) != 0)
          hashAlgorithm.ComputeHash(buffer, 0, countRead);
      }
    }

    [Profile]
    private static async Task ReadAndHashAsync()
    {
      var hashAlgorithm = HashAlgorithm.Create("SHA256");
      hashAlgorithm.Initialize();

      var webClient = new WebClient();
      var buffer = new byte[16 * 1024];
      using (var stream = webClient.OpenRead("http://www.nasa.gov/images/content/178493main_sig07-009-hires.jpg"))
      {
        int countRead;
        while ((countRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
          hashAlgorithm.ComputeHash(buffer, 0, countRead);
      }
    }
  }
}
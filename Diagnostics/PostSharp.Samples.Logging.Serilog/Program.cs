using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Serilog;
using PostSharp.Samples.Logging.BusinessLogic;
using Serilog;

// Add logging to all methods of this project.
[assembly: Log]

namespace PostSharp.Samples.Logging.Serilog
{
  [Log(AttributeExclude = true)]   // Removes logging from the Program class itself.
  internal class Program
  {
    private static void Main(string[] args)
    {
      // Configure Serilog.
      Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.File("serilog.log")
        .WriteTo.ColoredConsole()
        .CreateLogger();

      // Configure PostSharp Logging to use Serilog
      LoggingServices.DefaultBackend = new SerilogLoggingBackend();

      // Simulate some business logic.
      QueueProcessor.ProcessQueue(@".\Private$\SyncRequestQueue");
    }
  }
}
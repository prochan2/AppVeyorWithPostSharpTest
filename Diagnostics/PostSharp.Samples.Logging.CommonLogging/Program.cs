using Common.Logging;
using Common.Logging.Simple;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.CommonLogging;
using PostSharp.Samples.Logging.BusinessLogic;

// Adds logging to all methods of this project.
[assembly: Log]

namespace PostSharp.Samples.Logging.CommonLogging
{
  [Log(AttributeExclude = true)]  // Removes logging from the Program class itself.
  internal class Program
  {
    private static void Main(string[] args)
    {
      // Configure Common.Logging to direct outputs to the system console.
      LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter();

      // Configure PostSharp Logging to direct outputs to Common.Logging.
      LoggingServices.DefaultBackend = new CommonLoggingLoggingBackend();

      // Simulate some business logic.
      QueueProcessor.ProcessQueue(@".\Private$\SyncRequestQueue");
    }
  }
}
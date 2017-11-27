using PostSharp.Patterns.Diagnostics;
using PostSharp.Samples.Logging.BusinessLogic;
using ServiceStack.Logging;

// Add logging to all methods of this project.
[assembly: Log(AttributePriority = 0)]

// Exclude logging from the PostSharp.Samples.Logging.CustomBackend.ServiceStack namespace.
[assembly:
  Log(AttributePriority = 1, AttributeExclude = true,
    AttributeTargetTypes = "PostSharp.Samples.Logging.CustomBackend.ServiceStack.*")]

namespace PostSharp.Samples.Logging.CustomBackend.ServiceStack
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      // Configure PostSharp Logging to use ServiceStack.
      LoggingServices.DefaultBackend = new ServiceStackLoggingBackend();

      // Configure ServiceStack to output logs to the console.
      LogManager.LogFactory = new ConsoleLogFactory();

      // Simulate some business logic.
      QueueProcessor.ProcessQueue(@".\Private$\SyncRequestQueue");
    }
  }
}
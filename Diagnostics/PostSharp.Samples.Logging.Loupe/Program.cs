using System;
using Gibraltar.Agent;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Loupe;
using PostSharp.Samples.Logging.BusinessLogic;

// Add logging to all methods of this project.
[assembly: Log]

namespace PostSharp.Samples.Logging.Loupe
{
  [Log(AttributeExclude = true)]   // Removes logging from the Program class itself.
  internal class Program
  {
    private static void Main(string[] args)
    {
      try
      {
        // Initialize Loupe.
        Log.StartSession();

        // Configure PostSharp Logging to use Loupe.
        LoggingServices.DefaultBackend = new LoupeLoggingBackend();

        // Simulate some business logic.
        QueueProcessor.ProcessQueue(@".\Private$\SyncRequestQueue");

        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
      }
      catch (Exception ex)
      {
        //Optional but recommended - write fatal exceptions to loupe this way so the session is marked as crashed.
        Log.RecordException(ex, "Program", false);
        throw;
      }
      finally
      {
        // Close Loupe.
        Log.EndSession();
      }
    }
  }
}
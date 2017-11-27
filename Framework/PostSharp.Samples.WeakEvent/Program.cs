using System;

namespace PostSharp.Samples.WeakEvent
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var eventClient = new EventClient();
      MyEvent += eventClient.EventHandler;

      // Forcing GC here to prove that we are not collecting the handler when the client is alive.
      GC.Collect();

      // Raise the event when the client is alive.
      MyEvent(null, EventArgs.Empty);
      Console.WriteLine("EventHandlerCount: {0} (should be 1)", EventClient.EventHandlerCount);


      // Cause the client to be collected.
      var weakReference = new WeakReference(eventClient);
      eventClient = null;
      GC.Collect();

      Console.WriteLine("Client is alive: {0} (should be False)", weakReference.IsAlive);


      // Raise the event when the client is dead.
      EventClient.EventHandlerCount = 0;
      MyEvent(null, EventArgs.Empty);
      Console.WriteLine("EventHandlerCount: {0} (should be 0)", EventClient.EventHandlerCount);
    }

    [WeakEvent]
    private static event EventHandler MyEvent;
  }

  internal class EventClient
  {
    public static int EventHandlerCount;

    public void EventHandler(object sender, EventArgs e)
    {
      Console.WriteLine("Oops!");
      EventHandlerCount++;
    }
  }
}
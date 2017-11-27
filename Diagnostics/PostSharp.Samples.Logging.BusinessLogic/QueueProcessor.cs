using System;
using System.Threading;
using PostSharp.Patterns.Diagnostics;

namespace PostSharp.Samples.Logging.BusinessLogic
{
  public class QueueProcessor
  {
    private static readonly Logger logger = Logger.GetLogger();

    public static void ProcessQueue(string queuePath)
    {
      ProcessItem(new QueueItem(56));

      ProcessItem(new QueueItem(145));

      ProcessItem(new QueueItem(67));
    }

    private static void ProcessItem(QueueItem item)
    {
      var activity = logger.OpenActivity("Processing item {item}", item);
      try
      {
        var request = RequestStorage.GetRequest(item.Id);

        if (item.Id == 56)
        {
          activity.Write(LogLevel.Warning, "The entity {id} has been marked for deletion.", item.Id);
          activity.SetSuccess();
          return;
        }

        if (item.Id == 145)
          RequestStorage.GetUser(0);
        else
          RequestStorage.GetUser(14);


        Thread.Sleep(125);

        activity.SetSuccess();
      }
      catch (Exception e)
      {
        activity.SetException(e);
      }
    }
  }
}
namespace PostSharp.Samples.Logging.BusinessLogic
{
  public class QueueItem
  {
    public int Id;

    public QueueItem(int id)
    {
      Id = id;
    }

    public override string ToString()
    {
      return "SyncRequest EntityId=" + Id;
    }
  }
}
namespace PostSharp.Samples.Logging.BusinessLogic
{
  public class Request
  {
    public int Id;

    public Request(int id)
    {
      Id = id;
    }

    public override string ToString()
    {
      return "Request Id=" + Id;
    }
  }
}
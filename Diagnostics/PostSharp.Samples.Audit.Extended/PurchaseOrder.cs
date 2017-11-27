using PostSharp.Patterns.Diagnostics.Audit;

namespace PostSharp.Samples.Audit.Extended
{
  public class PurchaseOrder : BusinessObject
  {

    // Note the Audit aspect on this method.
    [Audit]
    public void AssignTo(Employee employee)
    {
    }
  }
}
using PostSharp.Patterns.Diagnostics.Audit;

namespace PostSharp.Samples.Audit
{
  public class PurchaseOrder : BusinessObject
  {

    // Not the Audit aspect on this method.
    [Audit]
    public void Approve(string comment = null)
    {
      // Details skipped.
    }
  }
}
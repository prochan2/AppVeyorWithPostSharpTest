using PostSharp.Patterns.Diagnostics.Backends.Audit;
using PostSharp.Patterns.Diagnostics.RecordBuilders;

namespace PostSharp.Samples.Audit.Extended
{
  public class ExtendedAuditBackend : AuditBackend
  {
    public override LogRecordBuilder CreateRecordBuilder()
    {
      return new ExtendedAuditRecordBuilder(this);
    }
  }
}
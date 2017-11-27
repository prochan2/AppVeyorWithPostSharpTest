using PostSharp.Samples.Authorization.Framework;
using PostSharp.Samples.Authorization.RoleBased;

namespace PostSharp.Samples.Authorization.BusinessObjects
{
  public class Invoice : Entity
  {
    [RequiresPermission(StandardPermission.Read, StandardPermission.Assign)]
    public BusinessUnit BusinessUnit { get; set; }

    public decimal Amount { get; set; }

    public string Description { get; set; }

    public override IRoleBasedSecurable SecurityParent => BusinessUnit;
  }
}
namespace PostSharp.Samples.Authorization.Framework
{
  /// <summary>
  ///   Enumeration of standard permissions.
  /// </summary>
  public enum StandardPermission
  {
    /// <summary>
    ///   No permission required.
    /// </summary>
    None,
    Create,
    Read,
    Write,
    Delete,
    Assign,
    ManageRoles
  }
}
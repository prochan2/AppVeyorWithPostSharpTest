namespace PostSharp.Samples.Authorization.Framework
{
  /// <summary>
  ///   A build-time object that represents a set of permissions for a given operation.
  ///   Permission factories are serialized at build time and deserialized at run time.
  ///   There can be one or many <see cref="IPermissionFactory" /> per method or field.
  /// </summary>
  public interface IPermissionFactory
  {
    /// <summary>
    ///   Creates the permission object for a given semantic.
    /// </summary>
    /// <param name="semantic">The semantic for which the <see cref="IPermission" /> is required.</param>
    /// <returns>A permission object.</returns>
    IPermission CreatePermission(OperationSemantic semantic);
  }
}
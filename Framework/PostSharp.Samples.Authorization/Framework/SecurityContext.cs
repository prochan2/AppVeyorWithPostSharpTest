namespace PostSharp.Samples.Authorization.Framework
{
  /// <summary>
  ///   Exposes the current security context.
  /// </summary>
  public static class SecurityContext
  {
    /// <summary>
    ///   Gets or sets the current <see cref="ISecurityContext" />. When this property is <c>null</c>, security is not
    ///   enforced.
    /// </summary>
    public static ISecurityContext Current { get; set; }
  }
}
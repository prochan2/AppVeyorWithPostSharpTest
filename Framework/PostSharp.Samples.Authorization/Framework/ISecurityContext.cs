namespace PostSharp.Samples.Authorization.Framework
{
  /// <summary>
  ///   Exposes the global properties of the security framework in the current context. This interface is exposed on the
  ///   <see cref="SecurityContext.Current" /> property.
  /// </summary>
  public interface ISecurityContext
  {
    /// <summary>
    ///   Gets the current <see cref="ISubject" />, i.e. typically the current user.
    /// </summary>
    ISubject Subject { get; }

    /// <summary>
    ///   Gets the current security policy.
    /// </summary>
    /// <remarks>
    ///   Note that the security framework may support several security policies.
    ///   In this case, the current property must be set to a policy aggregator.
    /// </remarks>
    ISecurityPolicy Policy { get; }

    /// <summary>
    ///   Gets the exception handler. This property is optional.
    /// </summary>
    ISecurityExceptionHandler ExceptionHandler { get; }
  }
}
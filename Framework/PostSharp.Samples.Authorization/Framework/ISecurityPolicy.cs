namespace PostSharp.Samples.Authorization.Framework
{
  /// <summary>
  ///   A security policy determines whether a given subject has a given permission on a given object.
  /// </summary>
  public interface ISecurityPolicy
  {
    /// <summary>
    ///   Determines whether a given subject has a given permission on a given object.
    /// </summary>
    /// <param name="subject">The subject.</param>
    /// <param name="permission">The permission.</param>
    /// <param name="securable">The object on which the permission is required.</param>
    /// <returns>
    ///   <c>true</c> if <paramref name="subject" /> has the required <paramref name="permission" /> on the given
    ///   <paramref name="securable" />, otherwise <c>false</c>.
    /// </returns>
    bool Evaluate(ISubject subject, IPermission permission, object securable);
  }
}
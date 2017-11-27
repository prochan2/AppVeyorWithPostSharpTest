using System.Reflection;

namespace PostSharp.Samples.Authorization.Framework
{
  /// <summary>
  ///   Exposes a method <see cref="OnSecurityException" /> invoked when the current <see cref="ISubject" /> does not have
  ///   the permission to execute an operation.
  /// </summary>
  public interface ISecurityExceptionHandler
  {
    /// <summary>
    ///   Method invoked when the current subject does not have the permission to execute an operation. A typical use case
    ///   of this method is to implement audit of security failures.
    /// </summary>
    /// <param name="member">The method, field or property being executed or accessed.</param>
    /// <param name="semantic">The semantic of the <paramref name="member" /> being accessed.</param>
    /// <param name="securable">The object on which the permission is missing.</param>
    /// <param name="subject">The subject executing the operation.</param>
    /// <param name="permission">The missing permission.</param>
    void OnSecurityException(MemberInfo member, OperationSemantic semantic, object securable, ISubject subject,
      IPermission permission);
  }
}
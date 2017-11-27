using System;

namespace PostSharp.Samples.Authorization.Framework
{
  /// <summary>
  ///   Represents a permission, i.e. something that the current subject (<see cref="ISubject" />) must
  ///   have in order to execute an operation (such as reading a field or executing a method).
  ///   A simple implementation is provided in the <see cref="Permission" /> class.
  /// </summary>
  public interface IPermission : IEquatable<IPermission>
  {
    /// <summary>
    ///   Gets the name of the permission, for inclusion in exception messages.
    /// </summary>
    string Name { get; }
  }
}
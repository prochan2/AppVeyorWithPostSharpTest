using System;

namespace PostSharp.Samples.Authorization.RoleBased
{
  /// <summary>
  ///   Represents a role.
  /// </summary>
  public interface IRole : IEquatable<IRole>
  {
  }
}
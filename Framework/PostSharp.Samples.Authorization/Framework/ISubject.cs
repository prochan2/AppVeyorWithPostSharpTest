using System;

namespace PostSharp.Samples.Authorization.Framework
{
  /// <summary>
  ///   Represents a security subject; typically a user or a service.
  /// </summary>
  public interface ISubject : IEquatable<ISubject>
  {
    /// <summary>
    ///   Gets the name of the subject, for inclusion in exception messages.
    /// </summary>
    string Name { get; }
  }
}
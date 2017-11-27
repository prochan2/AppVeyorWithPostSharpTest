namespace PostSharp.Samples.Authorization.Framework
{
  /// <summary>
  ///   Enumeration of semantics of fields, properties and methods.
  /// </summary>
  public enum OperationSemantic
  {
    /// <summary>
    ///   Invoking a method.
    /// </summary>
    Default,

    /// <summary>
    ///   Reading a field or a property.
    /// </summary>
    Read,

    /// <summary>
    ///   Writing a field or a property.
    /// </summary>
    Write
  }
}
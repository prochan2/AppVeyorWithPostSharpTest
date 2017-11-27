using System;

namespace PostSharp.Samples.Audit.Extended
{
  public class BusinessObject
  {
    public Guid Id { get; } = Guid.NewGuid();
  }
}
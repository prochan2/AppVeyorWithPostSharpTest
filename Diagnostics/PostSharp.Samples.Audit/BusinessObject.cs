using System;

namespace PostSharp.Samples.Audit
{
  public class BusinessObject
  {
    public Guid Id { get; } = Guid.NewGuid();
  }
}
using System;

namespace PostSharp.Samples.AutoDataContract
{
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class NotDataMemberAttribute : Attribute
  {
  }
}
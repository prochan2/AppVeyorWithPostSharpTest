using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Formatters;

namespace PostSharp.Samples.Logging
{
  [Log(AttributeExclude = true)]
  internal class FancyIntFormatter : Formatter<int>
  {
    public override void Write(UnsafeStringBuilder stringBuilder, int value)
    {
      switch (value)
      {
        case 0:
          stringBuilder.Append("zero");
          break;

        case 1:
          stringBuilder.Append("one");
          break;

        case 2:
          stringBuilder.Append("two");
          break;

        case 3:
          stringBuilder.Append("three");
          break;

        case 4:
          stringBuilder.Append("four");
          break;

        case 5:
          stringBuilder.Append("five");
          break;

        default:
          stringBuilder.Append(value);
          break;
      }
    }
  }
}
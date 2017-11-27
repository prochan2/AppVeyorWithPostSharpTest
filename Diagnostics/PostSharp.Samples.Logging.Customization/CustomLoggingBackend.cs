using System;
using System.Threading;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Console;
using PostSharp.Patterns.Diagnostics.RecordBuilders;
using PostSharp.Patterns.Formatters;

namespace PostSharp.Samples.Logging
{
  [Log(AttributeExclude = true)]
  internal class CustomLoggingBackend : ConsoleLoggingBackend
  {
    public override LogRecordBuilder CreateRecordBuilder()
    {
      return new RecordBuilder(this);
    }


    [Log(AttributeExclude = true)]
    private class RecordBuilder : ConsoleLogRecordBuilder
    {
      public RecordBuilder(ConsoleLoggingBackend backend) : base(backend)
      {
      }

      public override void SetParameter<T>(int index, string parameterName, ParameterDirection direction,
        string typeName, T value,
        IFormatter<T> formatter)
      {
        StringBuilder.Append('[');
        StringBuilder.Append(direction.ToString());
        StringBuilder.Append(']', ' ');

        base.SetParameter(index, parameterName, direction, typeName, value, formatter);
      }

      protected override void Write(UnsafeString message)
      {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} \u00A6 " + message);
      }
    }
  }
}
using System;

namespace PostSharp.Samples.CustomLogging.Aspects
{
  /// <summary>
  ///   A simplistic logger.
  /// </summary>
  public static class Logger
  {
    private static int indentLevel;

    public static void Indent()
    {
      indentLevel++;
    }

    public static void Unindent()
    {
      indentLevel--;
    }

    public static void WriteLine(string message)
    {
      Console.Write(new string(' ', 3 * indentLevel));
      Console.WriteLine(message);
    }
  }
}
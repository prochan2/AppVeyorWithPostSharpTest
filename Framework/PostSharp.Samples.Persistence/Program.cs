using System;

namespace PostSharp.Samples.Persistence
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine($"TestAppSettings.SomeBoolSetting={TestAppSettings.SomeBoolSetting}");
      Console.WriteLine($"TestAppSettings.SomeInt32Setting={TestAppSettings.SomeInt32Setting}");
      Console.WriteLine($"TestAppSettings.SomeNullableInt32Setting={TestAppSettings.SomeNullableInt32Setting}");
      Console.WriteLine($"TestAppSettings.SomeMissingInt32Setting={TestAppSettings.SomeMissingInt32Setting}");
      Console.WriteLine(
        $"TestAppSettings.SomeMissingNullableInt32Setting={TestAppSettings.SomeMissingNullableInt32Setting}");


      TestRegistryValues.ExecutionCount++;
      Console.WriteLine($"TestRegistryValues.ExecutionCount={TestRegistryValues.ExecutionCount}");
    }
  }
}
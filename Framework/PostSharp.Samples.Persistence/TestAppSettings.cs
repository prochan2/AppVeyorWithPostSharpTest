namespace PostSharp.Samples.Persistence
{
  [AppSettingsValue]
  public static class TestAppSettings
  {
    public static bool SomeBoolSetting;
    public static int SomeInt32Setting;

    // This setting has a default value but it is overridden in app.config.
    public static int SomeNullableInt32Setting = 50;


    // These settings have a default value, but they are not overridden in app.config.
    public static int SomeMissingInt32Setting = 7;

    public static int? SomeMissingNullableInt32Setting;
  }
}
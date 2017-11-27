using System.Web.Mvc;

namespace PostSharp.Samples.MiniProfiler
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
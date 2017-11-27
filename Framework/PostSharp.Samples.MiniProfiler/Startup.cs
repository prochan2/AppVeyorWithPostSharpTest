using Microsoft.Owin;
using Owin;
using PostSharp.Samples.MiniProfiler;

[assembly: OwinStartup(typeof(Startup))]

namespace PostSharp.Samples.MiniProfiler
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
    }
  }
}
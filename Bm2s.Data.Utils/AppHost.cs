using System.Reflection;
using Funq;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace Bm2s.Data.Utils
{
  public class AppHost : AppHostHttpListenerBase
  {
    public AppHost(string serviceName, params Assembly[] assembliesWithServices)
      : base(serviceName, assembliesWithServices)
    {
    }

    public override void Configure(Container container)
    {
    }
  }
}

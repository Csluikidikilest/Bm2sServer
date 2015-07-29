using Bm2s.Data.POS.Services.PointOfSale.Screen;
using Funq;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace Bm2s.Data.POS.Utils
{
  public class AppHost : Bm2s.Data.Utils.AppHost
  {
    public AppHost()
      : base("Bm2s HttpListener", typeof(Screens).Assembly)
    {
    }

    public override void Configure(Container container)
    {
      // Configuration du JSON de sortie
      JsConfig.EmitCamelCaseNames = true;
      JsConfig.DateHandler = JsonDateHandler.DCJSCompatible;

      container.Register<IDbConnectionFactory>(Bm2s.Data.POS.Utils.Datas.Instance.DbConnectionFactory);
    }
  }
}

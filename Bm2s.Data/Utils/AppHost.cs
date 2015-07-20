using Bm2s.Data.Services.Article.ArticleSubFamily;
using Funq;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace Bm2s.Data.Utils
{
  public class AppHost : AppHostHttpListenerBase
  {
    public AppHost()
      : base("Bm2s HttpListener", typeof(ArticleSubFamiliesService).Assembly)
    {
    }

    public override void Configure(Container container)
    {
      // Configuration du JSON de sortie
      JsConfig.EmitCamelCaseNames = true;
      JsConfig.DateHandler = JsonDateHandler.DCJSCompatible;

      container.Register<IDbConnectionFactory>(Utils.Datas.Instance.DbConnectionFactory);
    }
  }
}
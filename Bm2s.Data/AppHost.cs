using Bm2s.Data.Services.Article.ArticleSubFamily;
using Funq;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using ServiceStack.WebHost.Endpoints;

namespace Bm2s.Data
{
  /// <summary>
  /// Class pour le host des services
  /// </summary>
  public class AppHost : AppHostHttpListenerBase
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="AppHost" />
    /// </summary>
    public AppHost()
      : base("Bm2s HttpListener", typeof(ArticleSubFamilyService).Assembly)
    {
    }

    /// <summary>
    /// Configuration du host
    /// </summary>
    /// <param name="container">COntainer de la config</param>
    public override void Configure(Container container)
    {
      // Configuration du JSON de sortie
      JsConfig.EmitCamelCaseNames = true;
      JsConfig.DateHandler = JsonDateHandler.DCJSCompatible;

      container.Register<IDbConnectionFactory>(Utils.Datas.Instance.DbConnectionFactory);
      
      //ResponseFilters.Add((httpReq, httpResp, responseDto) =>
      //{
      //  httpResp.AddHeader("Expires", "0");
      //  httpResp.AddHeader(HttpHeaders.CacheControl, "max-age=0");
      //});
    }

    /// <summary>Fonction utilisé pour compresser les flux de réponse</summary>
    /// <typeparam name="TRequest">Type de la request</typeparam>
    /// <param name="actionContext">Context action</param>
    /// <returns>J'en sais rien ?</returns>
    //public override IServiceRunner<TRequest> CreateServiceRunner<TRequest>(ActionContext actionContext)
    //{
    //  return new MyServiceRunner<TRequest>(this, actionContext);
    //}
  }
}
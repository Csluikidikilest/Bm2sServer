using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Article.Nomenclature;

namespace Bm2s.Connectivity.Common.Article
{
  public class Nomenclature:ClientBase
  {
    public Nomenclature()
      : base()
    {
      this.Request = new Nomenclatures();
      this.Response = new NomenclaturesResponse();
    }

    public Nomenclatures Request { get; set; }

    public NomenclaturesResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }

    public void Post()
    {
      this.Response = this.ConnectorHelper.Post(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}

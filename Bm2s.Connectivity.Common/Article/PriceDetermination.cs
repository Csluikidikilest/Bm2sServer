using Bm2s.Connectivity.Utils;
using Bm2s.Response;

namespace Bm2s.Connectivity.Common.Article
{
  public class PriceDetermination : ClientBase
  {
    public PriceDetermination()
      : base()
    {
      this.Request = new Response.Common.Article.PriceDetermination.PriceDetermination();
      this.Response = new Response.Common.Article.PriceDetermination.PriceDeterminationResponse();
    }

    public Bm2s.Response.Common.Article.PriceDetermination.PriceDetermination Request { get; set; }

    public Bm2s.Response.Common.Article.PriceDetermination.PriceDeterminationResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}

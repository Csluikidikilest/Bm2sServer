using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Article.Price;

namespace Bm2s.Connectivity.Common.Article
{
  public class Price:ClientBase
  {
    public Price()
      : base()
    {
      this.Request = new Prices();
      this.Response = new PricesResponse();
    }

    public Prices Request { get; set; }

    public PricesResponse Response { get; set; }

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

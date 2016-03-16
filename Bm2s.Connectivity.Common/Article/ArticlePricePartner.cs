using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Article.ArticlePriceParner;

namespace Bm2s.Connectivity.Common.Article
{
  public class ArticlePricePartner : ClientBase
  {
    public ArticlePricePartner()
      : base()
    {
      this.Request = new ArticlePricePartners();
      this.Response = new ArticlePricePartnersResponse();
    }

    public ArticlePricePartners Request { get; set; }

    public ArticlePricePartnersResponse Response { get; set; }

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

    public void Delete()
    {
      this.Response = this.ConnectorHelper.Delete(this.Request);
      this.IsFilled = true;
    }

    protected override void LoadFromNameValueCollection(System.Collections.Specialized.NameValueCollection parameters)
    {
      this.Request.LoadFromNameValueCollection(parameters);
    }
  }
}

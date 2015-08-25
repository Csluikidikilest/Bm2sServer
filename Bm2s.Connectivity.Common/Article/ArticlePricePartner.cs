using Bm2s.Connectivity.Utils;
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
  }
}

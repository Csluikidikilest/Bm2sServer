using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Article.ArticlePricePartnerFamily;

namespace Bm2s.Connectivity.Common.Article
{
  public class ArticlePricePartnerFamily : ClientBase
  {
    public ArticlePricePartnerFamily()
      : base()
    {
      this.Request = new ArticlePricePartnerFamilies();
      this.Response = new ArticlePricePartnerFamiliesResponse();
    }

    public ArticlePricePartnerFamilies Request { get; set; }

    public ArticlePricePartnerFamiliesResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}

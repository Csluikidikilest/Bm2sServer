using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Article.ArticleSubFamilyPricePartnerFamily;

namespace Bm2s.Connectivity.Common.Article
{
  public class ArticleSubFamilyPricePartnerFamily : ClientBase
  {
    public ArticleSubFamilyPricePartnerFamily()
      : base()
    {
      this.Request = new ArticleSubFamilyPricePartnerFamilies();
      this.Response = new ArticleSubFamilyPricePartnerFamiliesResponse();
    }

    public ArticleSubFamilyPricePartnerFamilies Request { get; set; }

    public ArticleSubFamilyPricePartnerFamiliesResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}

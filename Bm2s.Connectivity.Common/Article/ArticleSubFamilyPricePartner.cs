using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Article.ArticleSubFamilyPricePartner;

namespace Bm2s.Connectivity.Common.Article
{
  public class ArticleSubFamilyPricePartner : ClientBase
  {
    public ArticleSubFamilyPricePartner()
      : base()
    {
      this.Request = new ArticleSubFamilyPricePartners();
      this.Response = new ArticleSubFamilyPricePartnersResponse();
    }

    public ArticleSubFamilyPricePartners Request { get; set; }

    public ArticleSubFamilyPricePartnersResponse Response { get; set; }

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

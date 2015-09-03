using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.ArticleSubFamilyPartnerFamilyVat;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class ArticleSubFamilyPartnerFamilyVat : ClientBase
  {
    public ArticleSubFamilyPartnerFamilyVat()
      : base()
    {
      this.Request = new ArticleSubFamilyPartnerFamilyVats();
      this.Response = new ArticleSubFamilyPartnerFamilyVatsResponse();
    }

    public ArticleSubFamilyPartnerFamilyVats Request { get; set; }

    public ArticleSubFamilyPartnerFamilyVatsResponse Response { get; set; }

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

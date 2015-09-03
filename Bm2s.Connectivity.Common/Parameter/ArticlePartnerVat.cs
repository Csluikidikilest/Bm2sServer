using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Parameter.ArticlePartnerVat;

namespace Bm2s.Connectivity.Common.Parameter
{
  public class ArticlePartnerVat : ClientBase
  {
    public ArticlePartnerVat()
      : base()
    {
      this.Request = new ArticlePartnerVats();
      this.Response = new ArticlePartnerVatsResponse();
    }

    public ArticlePartnerVats Request { get; set; }

    public ArticlePartnerVatsResponse Response { get; set; }

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

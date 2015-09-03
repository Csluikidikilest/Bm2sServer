using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Article.ArticleFamily;

namespace Bm2s.Connectivity.Common.Article
{
  public class ArticleFamily : ClientBase
  {
    public ArticleFamily()
      : base()
    {
      this.Request = new ArticleFamilies();
      this.Response = new ArticleFamiliesResponse();
    }

    public ArticleFamilies Request { get; set; }

    public ArticleFamiliesResponse Response { get;set; }

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

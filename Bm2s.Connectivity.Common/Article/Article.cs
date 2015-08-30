using Bm2s.Connectivity.Utils;
using Bm2s.Response;
using Bm2s.Response.Common.Article.Article;

namespace Bm2s.Connectivity.Common.Article
{
  public class Article : ClientBase
  {
    public Article()
      : base()
    {
      this.Request = new Articles();
      this.Response = new ArticlesResponse();
    }

    public Articles Request { get; set; }

    public ArticlesResponse Response { get; set; }

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

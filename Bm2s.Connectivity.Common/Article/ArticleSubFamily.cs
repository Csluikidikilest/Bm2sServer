using Bm2s.Connectivity.Utils;
using Bm2s.Response.Common.Article.ArticleSubFamily;

namespace Bm2s.Connectivity.Common.Article
{
  public class ArticleSubFamily : ClientBase
  {
    public ArticleSubFamily()
      : base()
    {
      this.Request = new ArticleSubFamilies();
      this.Response = new ArticleSubFamiliesResponse();
    }

    public ArticleSubFamilies Request { get; set; }

    public ArticleSubFamiliesResponse Response { get; set; }

    public void Get()
    {
      this.Response = this.ConnectorHelper.Get(this.Request);
      this.IsFilled = true;
    }
  }
}

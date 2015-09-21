using System.Collections.Generic;

namespace Bm2s.Response.Common.Article.ArticleSubFamily
{
  public class ArticleSubFamiliesResponse : Response
  {
    public ArticleSubFamiliesResponse()
    {
      this.ArticleSubFamilies = new List<Bm2s.Poco.Common.Article.ArticleSubFamily>();
    }

    public List<Bm2s.Poco.Common.Article.ArticleSubFamily> ArticleSubFamilies { get; set; }
  }
}

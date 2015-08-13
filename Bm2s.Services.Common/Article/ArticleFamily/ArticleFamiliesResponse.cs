using System.Collections.Generic;

namespace Bm2s.Services.Common.Article.ArticleFamily
{
  public class ArticleFamiliesResponse
  {
    public ArticleFamiliesResponse()
    {
      this.ArticleFamilies = new List<Bm2s.Poco.Common.Article.ArticleFamily>();
    }

    public List<Bm2s.Poco.Common.Article.ArticleFamily> ArticleFamilies { get; set; }
  }
}

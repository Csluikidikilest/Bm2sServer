using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Data.Services.Article.ArticleFamily
{
  [Route("/bm2s/articlefamilies", Verbs = "GET, POST")]
  [Route("/bm2s/articlefamilies/{Ids}", Verbs = "GET")]
  public class ArticleFamilies : IReturn<ArticleFamiliesResponse>
  {
    public ArticleFamilies()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Article.ArticleFamily ArticleFamily { get; set; }
  }
}

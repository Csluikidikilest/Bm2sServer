using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Data.Services.Article.ArticleSubFamily
{
  [Route("/bm2s/articlesubfamilies", Verbs = "GET, POST")]
  [Route("/bm2s/articlesubfamilies/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilies : IReturn<ArticleSubFamiliesResponse>
  {
    public ArticleSubFamilies()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Article.ArticleSubFamily ArticleSubFamily { get; set; }
  }
}

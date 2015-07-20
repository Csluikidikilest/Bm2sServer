using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Article.Article
{
  [Route("/bm2s/articles", Verbs = "GET, POST")]
  [Route("/bm2s/articles/{Ids}", Verbs = "GET")]
  public class Articles : IReturn<ArticlesResponse>
  {
    public Articles()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Article.Article Article { get; set; }
  }
}

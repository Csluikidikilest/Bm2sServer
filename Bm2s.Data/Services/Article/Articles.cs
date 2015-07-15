using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Data.Services.Article
{
  [Route("/bm2s/articles")]
  [Route("/bm2s/articles/{Ids}")]
  public class Articles : IReturn<List<BLL.Article.Article>>
  {
    public long[] Ids { get; set; }
    public Articles(params long[] ids)
    {
      this.Ids = ids;
    }
  }
}

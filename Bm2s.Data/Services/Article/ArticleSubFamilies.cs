using ServiceStack.ServiceHost;
using System.Collections.Generic;

namespace Bm2s.Data.Services.Article
{
  [Route("/bm2s/articlesubfamilies")]
  [Route("/bm2s/articlesubfamilies/{Ids}")]
  public class ArticleSubFamilies : IReturn<List<BLL.Article.ArticleSubFamily>>
  {
  }
}

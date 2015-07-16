using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Services.Article.ArticleSubFamily
{
  [Route("/bm2s/articlesubfamilies")]
  [Route("/bm2s/articlesubfamilies/{Ids}")]
  public class ArticleSubFamilies : IReturn<List<BLL.Article.ArticleSubFamily>>
  {
    public long[] Ids { get; set; }
    public ArticleSubFamilies(params long[] ids)
    {
      this.Ids = ids;
    }
  }
}

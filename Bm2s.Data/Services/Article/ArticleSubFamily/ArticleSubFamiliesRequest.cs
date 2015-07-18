using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Services.Article.ArticleSubFamily
{
  [Route("/bm2s/articlesubfamilies")]
  [Route("/bm2s/articlesubfamilies/{ArticleSubFamiliesIds}")]
  public class ArticleSubFamiliesRequest : IReturn<ArticleSubFamilyResponse>
  {
    public ArticleSubFamiliesRequest()
    {
      this.ArticleSubFamiliesIds = new List<int>();
    }

    public List<int> ArticleSubFamiliesIds { get; set; }

    public BLL.Article.ArticleSubFamily SubFamily { get; set; }
  }
}

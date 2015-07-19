using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Services.Article.ArticleSubFamily
{
  [Route("/bm2s/articlesubfamilies", Verbs = "GET, POST")]
  [Route("/bm2s/articlesubfamilies/{ArticleSubFamiliesIds}", Verbs = "GET")]
  public class ArticleSubFamiliesRequest : IReturn<ArticleSubFamilyResponse>
  {
    public ArticleSubFamiliesRequest()
    {
      this.ArticleSubFamiliesIds = new List<int>();
    }

    public List<int> ArticleSubFamiliesIds { get; set; }

    public BLL.Article.ArticleSubFamily ArticleSubFamily { get; set; }
  }
}

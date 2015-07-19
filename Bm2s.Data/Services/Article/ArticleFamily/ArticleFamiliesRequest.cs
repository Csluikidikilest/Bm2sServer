using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Services.Article.ArticleFamily
{
  [Route("/bm2s/articlefamilies", Verbs = "GET, POST")]
  [Route("/bm2s/articlefamilies/{ArticleFamiliesIds}", Verbs = "GET")]
  public class ArticleFamiliesRequest : IReturn<ArticleFamilyResponse>
  {
    public ArticleFamiliesRequest()
    {
      this.ArticleFamiliesIds = new List<int>();
    }

    public List<int> ArticleFamiliesIds { get; set; }

    public BLL.Article.ArticleFamily ArticleFamily { get; set; }
  }
}

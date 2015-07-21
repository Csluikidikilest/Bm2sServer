using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticleSubFamilyPricePartnerFamily
{
  [Route("/bm2s/articlesubfamilypricepartnerfamilies", Verbs = "GET, POST")]
  [Route("/bm2s/articlesubfamilypricepartnerfamilies/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilyPricePartnerFamilies : IReturn<ArticleSubFamilyPricePartnerFamiliesResponse>
  {
    public ArticleSubFamilyPricePartnerFamilies()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Article.ArticleSubFamilyPricePartnerFamily ArticleSubFamilyPricePartnerFamily { get; set; }

  }
}

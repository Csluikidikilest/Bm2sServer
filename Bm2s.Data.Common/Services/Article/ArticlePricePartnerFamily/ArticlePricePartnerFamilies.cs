using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticlePricePartnerFamily
{
  [Route("/bm2s/articlepricepartnerfamilies", Verbs = "GET, POST")]
  [Route("/bm2s/articlepricepartnerfamilies/{Ids}", Verbs = "GET")]
  public class ArticlePricePartnerFamilies : IReturn<ArticlePricePartnerFamiliesResponse>
  {
    public ArticlePricePartnerFamilies()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Article.ArticlePricePartnerFamily ArticlePricePartnerFamily { get; set; }
  }
}

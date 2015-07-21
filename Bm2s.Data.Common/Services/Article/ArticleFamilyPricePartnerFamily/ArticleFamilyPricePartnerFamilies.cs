using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticleFamilyPricePartnerFamily
{
  [Route("/bm2s/articlefamilypricepartnerfamilies", Verbs = "GET, POST")]
  [Route("/bm2s/articlefamilypricepartnerfamilies/{Ids}", Verbs = "GET")]
  public class ArticleFamilyPricePartnerFamilies : IReturn<ArticleFamilyPricePartnerFamiliesResponse>
  {
    public ArticleFamilyPricePartnerFamilies()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Article.ArticleFamilyPricePartnerFamily ArticleFamilyPricePartnerFamily { get; set; }
  }
}

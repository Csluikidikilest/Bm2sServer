using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Article.ArticleFamilyPricePartnerFamily
{
  [Route("/bm2s/articlefamilypricepartnerfamilies", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/articlefamilypricepartnerfamilies/{Ids}", Verbs = "GET")]
  public class ArticleFamilyPricePartnerFamilies : Request, IReturn<ArticleFamilyPricePartnerFamiliesResponse>
  {
    public ArticleFamilyPricePartnerFamilies()
    {
      this.Ids = new List<int>();
    }

    public int ArticleFamilyId { get; set; }

    public DateTime? Date { get; set; }

    public int PartnerFamilyId { get; set; }

    public Bm2s.Poco.Common.Article.ArticleFamilyPricePartnerFamily ArticleFamilyPricePartnerFamily { get; set; }
  }
}

using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Article.ArticleSubFamilyPricePartnerFamily
{
  [Route("/bm2s/articlesubfamilypricepartnerfamilies", Verbs = "GET, POST")]
  [Route("/bm2s/articlesubfamilypricepartnerfamilies/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilyPricePartnerFamilies : IReturn<ArticleSubFamilyPricePartnerFamiliesResponse>
  {
    public ArticleSubFamilyPricePartnerFamilies()
    {
      this.Ids = new List<int>();
    }

    public int ArticleSubFamilyId { get; set; }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public int PartnerFamilyId { get; set; }

    public Bm2s.Poco.Common.Article.ArticleSubFamilyPricePartnerFamily ArticleSubFamilyPricePartnerFamily { get; set; }

  }
}

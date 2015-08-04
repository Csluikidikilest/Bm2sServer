using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticleFamilyPricePartner
{
  [Route("/bm2s/articlefamilypricepartners", Verbs = "GET, POST")]
  [Route("/bm2s/articlefamilypricepartners/{Ids}", Verbs = "GET")]
  public class ArticleFamilyPricePartners : IReturn<ArticleFamilyPricePartnersResponse>
  {
    public ArticleFamilyPricePartners()
    {
      this.Ids = new List<int>();
    }

    public int ArticleFamilyId { get; set; }

    public List<int> Ids { get; set; }

    public int PartnerId { get; set; }

    public BLL.Article.ArticleFamilyPricePartner ArticleFamilyPricePartner { get; set; }
  }
}

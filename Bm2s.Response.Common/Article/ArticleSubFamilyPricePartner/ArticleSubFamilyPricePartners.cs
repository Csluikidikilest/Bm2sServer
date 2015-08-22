using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Response.Common.Article.ArticleSubFamilyPricePartner
{
  [Route("/bm2s/articlesubfamilypricepartners", Verbs = "GET, POST")]
  [Route("/bm2s/articlesubfamilypricepartners/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilyPricePartners : IReturn<ArticleSubFamilyPricePartnersResponse>
  {
    public ArticleSubFamilyPricePartners()
    {
      this.Ids = new List<int>();
    }

    public int ArticleSubFamilyId { get; set; }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public int PartnerId { get; set; }

    public Bm2s.Poco.Common.Article.ArticleSubFamilyPricePartner ArticleSubFamilyPricePartner { get; set; }
  }
}

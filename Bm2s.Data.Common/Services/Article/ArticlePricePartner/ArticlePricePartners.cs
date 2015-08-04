using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Article.ArticlePriceParner
{
  [Route("/bm2s/articlepricepartners", Verbs = "GET, POST")]
  [Route("/bm2s/articlepricepartners/{Ids}", Verbs = "GET")]
  public class ArticlePricePartners : IReturn<ArticlePricePartnersResponse>
  {
    public ArticlePricePartners()
    {
      this.Ids = new List<int>();
    }

    public int ArticleId { get; set; }

    public List<int> Ids { get; set; }

    public int PartnerId { get; set; }

    public BLL.Article.ArticlePricePartner ArticlePriceParner { get; set; }
  }
}

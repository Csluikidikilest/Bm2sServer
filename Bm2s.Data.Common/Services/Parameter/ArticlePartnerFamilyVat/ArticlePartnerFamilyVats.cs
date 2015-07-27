using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.ArticlePartnerFamilyVat
{
  [Route("/bm2s/articlepartnerfamilyvats", Verbs = "GET, POST")]
  [Route("/bm2s/articlepartnerfamilyvats/{Ids}", Verbs = "GET")]
  public class ArticlePartnerFamilyVats
  {
    public ArticlePartnerFamilyVats()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.ArticlePartnerFamilyVat ArticlePartnerFamilyVat { get; set; }
  }
}

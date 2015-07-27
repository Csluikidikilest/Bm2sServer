using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.ArticleSubFamilyPartnerFamilyVat
{
  [Route("/bm2s/articlesubfamilypartnerfamilyvats", Verbs = "GET, POST")]
  [Route("/bm2s/articlesubfamilypartnerfamilyvats/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilyPartnerFamilyVats
  {
    public ArticleSubFamilyPartnerFamilyVats()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.ArticleSubFamilyPartnerFamilyVat ArticleSubFamilyPartnerFamilyVat { get; set; }
  }
}

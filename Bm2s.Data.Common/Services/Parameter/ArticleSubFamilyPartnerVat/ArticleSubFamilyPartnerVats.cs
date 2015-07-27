using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.ArticleSubFamilyPartnerVat
{
  [Route("/bm2s/articlesubfamilypartnervats", Verbs = "GET, POST")]
  [Route("/bm2s/articlesubfamilypartnervats/{Ids}", Verbs = "GET")]
  public class ArticleSubFamilyPartnerVats
  {
    public ArticleSubFamilyPartnerVats()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.ArticleSubFamilyPartnerVat ArticleSubFamilyPartnerVat { get; set; }
  }
}

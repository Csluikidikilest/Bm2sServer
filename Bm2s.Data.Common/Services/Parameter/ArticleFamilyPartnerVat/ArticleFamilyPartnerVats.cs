using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.ArticleFamilyPartnerVat
{
  [Route("/bm2s/articlefamilypartnervats", Verbs = "GET, POST")]
  [Route("/bm2s/articlefamilypartnervats/{Ids}", Verbs = "GET")]
  public class ArticleFamilyPartnerVats : IReturn<ArticleFamilyPartnerVatsResponse>
  {
    public ArticleFamilyPartnerVats()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.ArticleFamilyPartnerVat ArticleFamilyPartnerVat { get; set; }
  }
}

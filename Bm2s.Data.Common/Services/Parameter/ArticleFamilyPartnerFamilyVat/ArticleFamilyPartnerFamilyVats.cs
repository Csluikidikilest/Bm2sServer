using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.ArticleFamilyPartnerFamilyVat
{
  [Route("/bm2s/articlefamilypartnerfamilyvats", Verbs = "GET, POST")]
  [Route("/bm2s/articlefamilypartnerfamilyvats/{Ids}", Verbs = "GET")]
  public class ArticleFamilyPartnerFamilyVats : IReturn<ArticleFamilyPartnerFamilyVatsResponse>
  {
    public ArticleFamilyPartnerFamilyVats()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.ArticleFamilyPartnerFamilyVat ArticleFamilyPartnerFamilyVat { get; set; }
  }
}

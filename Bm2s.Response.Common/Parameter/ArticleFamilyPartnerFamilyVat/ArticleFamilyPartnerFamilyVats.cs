using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.ArticleFamilyPartnerFamilyVat
{
  [Route("/bm2s/articlefamilypartnerfamilyvats", Verbs = "GET, POST")]
  [Route("/bm2s/articlefamilypartnerfamilyvats/{Ids}", Verbs = "GET")]
  public class ArticleFamilyPartnerFamilyVats : Request, IReturn<ArticleFamilyPartnerFamilyVatsResponse>
  {
    public ArticleFamilyPartnerFamilyVats()
    {
      this.Ids = new List<int>();
    }

    public int ArticleFamilyId { get; set; }

    public int PartnerFamilyId { get; set; }

    public int VatId { get; set; }

    public Bm2s.Poco.Common.Parameter.ArticleFamilyPartnerFamilyVat ArticleFamilyPartnerFamilyVat { get; set; }
  }
}

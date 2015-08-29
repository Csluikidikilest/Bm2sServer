using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Parameter.ArticleFamilyPartnerVat
{
  [Route("/bm2s/articlefamilypartnervats", Verbs = "GET, POST")]
  [Route("/bm2s/articlefamilypartnervats/{Ids}", Verbs = "GET")]
  public class ArticleFamilyPartnerVats : Request, IReturn<ArticleFamilyPartnerVatsResponse>
  {
    public ArticleFamilyPartnerVats()
    {
      this.Ids = new List<int>();
    }

    public int ArticleFamilyId { get; set; }

    public int PartnerId { get; set; }

    public int VatId { get; set; }

    public Bm2s.Poco.Common.Parameter.ArticleFamilyPartnerVat ArticleFamilyPartnerVat { get; set; }
  }
}

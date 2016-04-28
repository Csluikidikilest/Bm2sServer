using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Partner.PartnerPartnerFamily
{
  [Route("/bm2s/partnerpartnerfamilies", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/partnerpartnerfamilies/{Ids}", Verbs = "GET")]
  public class PartnerPartnerFamilies : Request, IReturn<PartnerPartnerFamiliesResponse>
  {
    public PartnerPartnerFamilies()
    {
      this.Ids = new List<int>();
    }

    public int PartnerFamilyId { get; set; }

    public int PartnerId { get; set; }

    public Bm2s.Poco.Common.Partner.PartnerPartnerFamily PartnerPartnerFamily { get; set; }
  }
}

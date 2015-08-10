using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Partner.PartnerPartnerFamily
{
  [Route("/bm2s/partnerpartnerfamilies", Verbs = "GET, POST")]
  [Route("/bm2s/partnerpartnerfamilies/{Ids}", Verbs = "GET")]
  public class PartnerPartnerFamilies : IReturn<PartnerPartnerFamiliesResponse>
  {
    public PartnerPartnerFamilies()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public int PartnerFamilyId { get; set; }

    public int PartnerId { get; set; }

    public Bm2s.Data.Common.BLL.Partner.PartnerPartnerFamily PartnerPartnerFamily { get; set; }
  }
}

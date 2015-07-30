using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Partner.PartnerContact
{
  [Route("/bm2s/partnercontacts", Verbs = "GET, POST")]
  [Route("/bm2s/partnercontacts/{Ids}", Verbs = "GET")]
  public class PartnerContacts : IReturn<PartnerContactsResponse>
  {
    public PartnerContacts()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Partner.PartnerContact PartnerContact { get; set; }
  }
}

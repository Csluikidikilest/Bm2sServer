using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Partner.PartnerAddress
{
  [Route("/bm2s/partneraddresses", Verbs = "GET, POST")]
  [Route("/bm2s/partneraddresses/{Ids}", Verbs = "GET")]
  public class PartnerAddresses : IReturn<PartnerAddressesResponse>
  {
    public PartnerAddresses()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Partner.PartnerAddress PartnerAddress { get; set; }
  }
}

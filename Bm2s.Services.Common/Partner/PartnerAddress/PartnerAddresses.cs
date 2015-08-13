using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Partner.PartnerAddress
{
  [Route("/bm2s/partneraddresses", Verbs = "GET, POST")]
  [Route("/bm2s/partneraddresses/{Ids}", Verbs = "GET")]
  public class PartnerAddresses : IReturn<PartnerAddressesResponse>
  {
    public PartnerAddresses()
    {
      this.Ids = new List<int>();
    }

    public int AddressId { get; set; }

    public int AddressTypeId { get; set; }

    public List<int> Ids { get; set; }

    public int PartnerId { get; set; }

    public Bm2s.Poco.Common.Partner.PartnerAddress PartnerAddress { get; set; }
  }
}

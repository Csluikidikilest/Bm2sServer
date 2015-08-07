using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.HeaderPartnerAddress
{
  [Route("/bm2s/headerpartneraddresses", Verbs = "GET, POST")]
  [Route("/bm2s/headerpartneraddresses/{Ids}", Verbs = "GET")]
  public class HeaderPartnerAddresses : IReturn<HeaderPartnerAddressesResponse>
  {
    public HeaderPartnerAddresses()
    {
      this.Ids = new List<int>();
    }

    public int AddressId { get; set; }

    public int AddressTypeId { get; set; }

    public int HeaderId { get; set; }

    public List<int> Ids { get; set; }

    public int PartnerId { get; set; }

    public BLL.Trade.HeaderPartnerAddress HeaderPartnerAddress { get; set; }
  }
}

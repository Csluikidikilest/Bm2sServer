using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Trade.HeaderPartnerAddress
{
  [Route("/bm2s/headerpartneraddresses", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/headerpartneraddresses/{Ids}", Verbs = "GET")]
  public class HeaderPartnerAddresses : Request, IReturn<HeaderPartnerAddressesResponse>
  {
    public HeaderPartnerAddresses()
    {
      this.Ids = new List<int>();
    }

    public int AddressId { get; set; }

    public int AddressTypeId { get; set; }

    public int HeaderId { get; set; }

    public int PartnerId { get; set; }

    public Bm2s.Poco.Common.Trade.HeaderPartnerAddress HeaderPartnerAddress { get; set; }
  }
}

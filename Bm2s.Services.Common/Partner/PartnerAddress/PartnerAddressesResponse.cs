using System.Collections.Generic;

namespace Bm2s.Services.Common.Partner.PartnerAddress
{
  class PartnerAddressesResponse
  {
    public PartnerAddressesResponse()
    {
      this.PartnerAddresses = new List<Bm2s.Poco.Common.Partner.PartnerAddress>();
    }

    public List<Bm2s.Poco.Common.Partner.PartnerAddress> PartnerAddresses { get; set; }
  }
}

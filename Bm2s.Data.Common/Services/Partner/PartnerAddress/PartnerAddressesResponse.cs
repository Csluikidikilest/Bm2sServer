using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Partner.PartnerAddress
{
  class PartnerAddressesResponse
  {
    public PartnerAddressesResponse()
    {
      this.PartnerAddresses = new List<BLL.Partner.PartnerAddress>();
    }

    public List<BLL.Partner.PartnerAddress> PartnerAddresses { get; set; }
  }
}

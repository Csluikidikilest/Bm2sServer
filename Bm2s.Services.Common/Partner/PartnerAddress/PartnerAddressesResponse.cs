using System.Collections.Generic;

namespace Bm2s.Services.Common.Partner.PartnerAddress
{
  class PartnerAddressesResponse
  {
    public PartnerAddressesResponse()
    {
      this.PartnerAddresses = new List<Bm2s.Data.Common.BLL.Partner.PartnerAddress>();
    }

    public List<Bm2s.Data.Common.BLL.Partner.PartnerAddress> PartnerAddresses { get; set; }
  }
}

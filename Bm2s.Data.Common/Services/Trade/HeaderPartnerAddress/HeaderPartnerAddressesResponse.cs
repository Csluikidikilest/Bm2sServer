using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.Common.Services.Trade.HeaderPartnerAddress
{
  public class HeaderPartnerAddressesResponse
  {
    public HeaderPartnerAddressesResponse()
    {
      this.HeaderPartnerAddresses = new List<BLL.Trade.HeaderPartnerAddress>();
    }

    public List<BLL.Trade.HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }
  }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services.Common.Trade.HeaderPartnerAddress
{
  public class HeaderPartnerAddressesResponse
  {
    public HeaderPartnerAddressesResponse()
    {
      this.HeaderPartnerAddresses = new List<Bm2s.Poco.Common.Trade.HeaderPartnerAddress>();
    }

    public List<Bm2s.Poco.Common.Trade.HeaderPartnerAddress> HeaderPartnerAddresses { get; set; }
  }
}
﻿using System.Collections.Generic;

namespace Bm2s.Response.Common.Partner.PartnerAddress
{
  public class PartnerAddressesResponse : Response
  {
    public PartnerAddressesResponse()
    {
      this.PartnerAddresses = new List<Bm2s.Poco.Common.Partner.PartnerAddress>();
    }

    public List<Bm2s.Poco.Common.Partner.PartnerAddress> PartnerAddresses { get; set; }
  }
}

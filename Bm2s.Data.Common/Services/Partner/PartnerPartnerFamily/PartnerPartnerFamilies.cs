﻿using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Partner.PartnerPartnerFamily
{
  [Route("/bm2s/partnerpartnerfamilies", Verbs = "GET, POST")]
  [Route("/bm2s/partnerpartnerfamilies/{Ids}", Verbs = "GET")]
  public class PartnerPartnerFamilies
  {
    public PartnerPartnerFamilies()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Partner.PartnerPartnerFamily PartnerPartnerFamily { get; set; }
  }
}
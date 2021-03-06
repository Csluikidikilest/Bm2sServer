﻿using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Partner.PartnerFamily
{
  [Route("/bm2s/partnerfamilies", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/partnerfamilies/{Ids}", Verbs = "GET")]
  public class PartnerFamilies : Request, IReturn<PartnerFamiliesResponse>
  {
    public PartnerFamilies()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public DateTime? Date { get; set; }

    public string Designation { get; set; }

    public Bm2s.Poco.Common.Partner.PartnerFamily PartnerFamily { get; set; }
  }
}

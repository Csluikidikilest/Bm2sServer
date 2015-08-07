﻿using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Partner.PartnerFil
{
  [Route("/bm2s/partnerfiles", Verbs = "GET, POST")]
  [Route("/bm2s/partnerfiles/{Ids}", Verbs = "GET")]
  public class PartnerFiles : IReturn<PartnerFilesResponse>
  {
    public PartnerFiles()
    {
      this.Ids = new List<int>();
    }

    public DateTime? AddingDate { get; set; }

    public List<int> Ids { get; set; }

    public string Name { get; set; }

    public int PartnerId { get; set; }

    public int UserId { get; set; }

    public BLL.Partner.PartnerFile PartnerFile { get; set; }
  }
}

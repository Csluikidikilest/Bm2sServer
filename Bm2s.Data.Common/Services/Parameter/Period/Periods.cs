﻿using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.Period
{
  [Route("/bm2s/periods", Verbs = "GET, POST")]
  [Route("/bm2s/periods/{Ids}", Verbs = "GET")]
  public class Periods
  {
    public Periods()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.Period Period { get; set; }
  }
}
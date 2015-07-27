﻿using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.Vat
{
  [Route("/bm2s/vats", Verbs = "GET, POST")]
  [Route("/bm2s/vats/{Ids}", Verbs = "GET")]
  public class Vats
  {
    public Vats()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.Vat Vat { get; set; }
  }
}

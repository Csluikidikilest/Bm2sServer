﻿using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.User.Module
{
  [Route("/bm2s/modules", Verbs = "GET, POST")]
  [Route("/bm2s/modules/{Ids}", Verbs = "GET")]
  public class Modules : Request, IReturn<ModulesResponse>
  {
    public Modules()
    {
      this.Ids = new List<int>();
    }

    public string Code { get; set; }

    public string Name { get; set; }

    public Bm2s.Poco.Common.User.Module Module { get; set; }
  }
}

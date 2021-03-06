﻿using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Trade.HeaderStatusStep
{
  [Route("/bm2s/headerstatussteps", Verbs = "GET, POST, DELETE")]
  [Route("/bm2s/headerstatussteps/{Ids}", Verbs = "GET")]
  public class HeaderStatusSteps : Request, IReturn<HeaderStatusStepsResponse>
  {
    public HeaderStatusSteps()
    {
      this.Ids = new List<int>();
    }

    public int HeaderStatusChildId { get; set; }

    public int HeaderStatusParentId { get; set; }

    public Bm2s.Poco.Common.Trade.HeaderStatusStep HeaderStatusStep { get; set; }
  }
}

using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Response.Common.Trade.HeaderOrigin
{
  [Route("/bm2s/headerorigins", Verbs = "GET, POST")]
  [Route("/bm2s/headerorigins/{Ids}", Verbs = "GET")]
  public class HeaderOrigins : IReturn<HeaderOriginsResponse>
  {
    public HeaderOrigins()
    {
      this.Ids = new List<int>();
    }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public int HeaderChildId { get; set; }

    public int HeaderParentId { get; set; }

    public Bm2s.Poco.Common.Trade.HeaderOrigin HeaderOrigin { get; set; }
  }
}

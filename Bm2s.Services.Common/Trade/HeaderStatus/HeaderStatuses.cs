using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Trade.HeaderStatus
{
  [Route("/bm2s/headerstatuses", Verbs = "GET, POST")]
  [Route("/bm2s/headerstatuses/{Ids}", Verbs = "GET")]
  public class HeaderStatuses : IReturn<HeaderStatusesResponse>
  {
    public HeaderStatuses()
    {
      this.Ids = new List<int>();
    }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public bool InterveneOnStock { get; set; }

    public string Name { get; set; }

    public Bm2s.Poco.Common.Trade.HeaderStatus HeaderStatus { get; set; }
  }
}

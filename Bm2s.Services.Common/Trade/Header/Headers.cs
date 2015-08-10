using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Trade.Header
{
  [Route("/bm2s/headers", Verbs = "GET, POST")]
  [Route("/bm2s/headers/{Ids}", Verbs = "GET")]
  public class Headers : IReturn<HeadersResponse>
  {
    public Headers()
    {
      this.Ids = new List<int>();
    }

    public int ActivityId { get; set; }

    public DateTime? Date { get; set; }

    public string Description { get; set; }

    public int HeaderStatusId { get; set; }

    public List<int> Ids { get; set; }

    public bool IsSell { get; set; }

    public string Reference { get; set; }

    public int UserId { get; set; }

    public Bm2s.Data.Common.BLL.Trade.Header Header { get; set; }
  }
}

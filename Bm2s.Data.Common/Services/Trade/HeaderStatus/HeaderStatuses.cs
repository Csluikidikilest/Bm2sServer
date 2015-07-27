using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.HeaderStatus
{
  [Route("/bm2s/headerstatuses", Verbs = "GET, POST")]
  [Route("/bm2s/headerstatuses/{Ids}", Verbs = "GET")]
  public class HeaderStatuses
  {
    public HeaderStatuses()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Trade.HeaderStatus HeaderStatus { get; set; }
  }
}

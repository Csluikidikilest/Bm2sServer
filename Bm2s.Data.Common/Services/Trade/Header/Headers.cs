using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Trade.Header
{
  [Route("/bm2s/headers", Verbs = "GET, POST")]
  [Route("/bm2s/headers/{Ids}", Verbs = "GET")]
  public class Headers
  {
    public Headers()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Trade.Header Header { get; set; }
  }
}

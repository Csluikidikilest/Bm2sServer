using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Parameter.InventoryHeader
{
  [Route("/bm2s/inventoryheaders", Verbs = "GET, POST")]
  [Route("/bm2s/inventoryheaders/{Ids}", Verbs = "GET")]
  public class InventoryHeaders : IReturn<InventoryHeadersResponse>
  {
    public InventoryHeaders()
    {
      this.Ids = new List<int>();
    }

    public DateTime? Date { get; set; }

    public List<int> Ids { get; set; }

    public int Type { get; set; }

    public Bm2s.Poco.Common.Parameter.InventoryHeader InventoryHeader { get; set; }
  }
}

using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Data.Common.Services.Parameter.InventoryHeader
{
  [Route("/bm2s/inventoryheaders", Verbs = "GET, POST")]
  [Route("/bm2s/inventoryheaders/{Ids}", Verbs = "GET")]
  public class InventoryHeaders : IReturn<InventoryHeadersResponse>
  {
    public InventoryHeaders()
    {
      this.Ids = new List<int>();
    }

    public List<int> Ids { get; set; }

    public BLL.Parameter.InventoryHeader InventoryHeader { get; set; }
  }
}

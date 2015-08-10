using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Bm2s.Services.Common.Parameter.InventoryLine
{
  [Route("/bm2s/inventorylines", Verbs = "GET, POST")]
  [Route("/bm2s/inventorylines/{Ids}", Verbs = "GET")]
  public class InventoryLines : IReturn<InventoryLinesResponse>
  {
    public InventoryLines()
    {
      this.Ids = new List<int>();
    }

    public int ArticleId { get; set; }

    public List<int> Ids { get; set; }

    public int InventoryHeaderId { get; set; }

    public Bm2s.Data.Common.BLL.Parameter.InventoryLine InventoryLine { get; set; }
  }
}

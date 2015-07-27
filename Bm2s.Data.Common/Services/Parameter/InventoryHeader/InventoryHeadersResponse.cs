using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.InventoryHeader
{
  public class InventoryHeadersResponse
  {
    public InventoryHeadersResponse()
    {
      this.InventoryHeaders = new List<BLL.Parameter.InventoryHeader>();
    }

    public List<BLL.Parameter.InventoryHeader> InventoryHeaders { get; set; }
  }
}

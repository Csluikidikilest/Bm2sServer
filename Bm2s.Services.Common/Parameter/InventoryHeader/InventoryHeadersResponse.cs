using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.InventoryHeader
{
  public class InventoryHeadersResponse
  {
    public InventoryHeadersResponse()
    {
      this.InventoryHeaders = new List<Bm2s.Data.Common.BLL.Parameter.InventoryHeader>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.InventoryHeader> InventoryHeaders { get; set; }
  }
}

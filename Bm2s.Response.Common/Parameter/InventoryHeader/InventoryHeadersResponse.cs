using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.InventoryHeader
{
  public class InventoryHeadersResponse : Response
  {
    public InventoryHeadersResponse()
    {
      this.InventoryHeaders = new List<Bm2s.Poco.Common.Parameter.InventoryHeader>();
    }

    public List<Bm2s.Poco.Common.Parameter.InventoryHeader> InventoryHeaders { get; set; }
  }
}

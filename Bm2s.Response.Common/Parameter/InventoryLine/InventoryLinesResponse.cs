using System.Collections.Generic;

namespace Bm2s.Response.Common.Parameter.InventoryLine
{
  public class InventoryLinesResponse : Response
  {
    public InventoryLinesResponse()
    {
      this.InventoryLines = new List<Bm2s.Poco.Common.Parameter.InventoryLine>();
    }

    public List<Bm2s.Poco.Common.Parameter.InventoryLine> InventoryLines { get; set; }
  }
}

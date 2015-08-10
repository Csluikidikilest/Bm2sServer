using System.Collections.Generic;

namespace Bm2s.Services.Common.Parameter.InventoryLine
{
  public class InventoryLinesResponse
  {
    public InventoryLinesResponse()
    {
      this.InventoryLines = new List<Bm2s.Data.Common.BLL.Parameter.InventoryLine>();
    }

    public List<Bm2s.Data.Common.BLL.Parameter.InventoryLine> InventoryLines { get; set; }
  }
}

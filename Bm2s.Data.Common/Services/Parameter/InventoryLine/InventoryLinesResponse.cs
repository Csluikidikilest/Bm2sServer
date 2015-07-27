using System.Collections.Generic;

namespace Bm2s.Data.Common.Services.Parameter.InventoryLine
{
  public class InventoryLinesResponse
  {
    public InventoryLinesResponse()
    {
      this.InventoryLines = new List<BLL.Parameter.InventoryLine>();
    }

    public List<BLL.Parameter.InventoryLine> InventoryLines { get; set; }
  }
}

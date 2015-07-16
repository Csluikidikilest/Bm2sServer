using ServiceStack.DataAnnotations;
using System;

namespace Bm2s.Data.BLL.Parameter
{
  public class InventoryHeader : Table
  {
    public DateTime Date { get; set; }

    public int Type { get; set; }
  }
}

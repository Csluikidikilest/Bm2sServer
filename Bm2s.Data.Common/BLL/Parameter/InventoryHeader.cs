using ServiceStack.DataAnnotations;
using System;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class InventoryHeader : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public DateTime Date { get; set; }

    public int Type { get; set; }
  }
}

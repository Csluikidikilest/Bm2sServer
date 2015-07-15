using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class InventoryHeader
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    public DateTime Date { get; set; }

    public int Type { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class UnitConversion
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Default(0)]
    public int Quantity { get; set; }

    [Default(1)]
    public int Multiplier { get; set; }

    [References(typeof(Unit))]
    public int ChildId { get; set; }

    [References(typeof(Unit))]
    public int ParentId { get; set; }
  }
}

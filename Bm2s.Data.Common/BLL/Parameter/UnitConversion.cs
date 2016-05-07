using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  [Alias("Unco")]
  public class UnitConversion : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public int Quantity { get; set; }

    [Default(1)]
    public int Multiplier { get; set; }

    [Alias("UnpaId")]
    [References(typeof(Unit))]
    public int UnitParentId { get; set; }

    [Alias("UnchId")]
    [References(typeof(Unit))]
    public int UnitChildId { get; set; }
  }
}

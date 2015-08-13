using System.Linq;
using Bm2s.Data.Common.BLL.Trade;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class AffairHeader : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [References(typeof(Affair))]
    public int AffairId { get; set; }

    [References(typeof(Header))]
    public int HeaderId { get; set; }
  }
}

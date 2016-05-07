using System.Linq;
using Bm2s.Data.Common.BLL.Trade;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  [Alias("Afhe")]
  public class AffairHeader : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Alias("AffaId")]
    [References(typeof(Affair))]
    public int AffairId { get; set; }

    [Alias("HeadId")]
    [References(typeof(Header))]
    public int HeaderId { get; set; }
  }
}

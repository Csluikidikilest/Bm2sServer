using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  [Alias("Hess")]
  public class HeaderStatusStep : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Alias("HespId")]
    [References(typeof(HeaderStatus))]
    public int HeaderStatusParentId { get; set; }

    [Alias("HescId")]
    [References(typeof(HeaderStatus))]
    public int HeaderStatusChildId { get; set; }
  }
}

using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  [Alias("Heor")]
  public class HeaderOrigin : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public DateTime Date { get; set; }

    [Alias("HepaId")]
    [References(typeof(Header))]
    public int HeaderParentId { get; set; }

    [Alias("HechId")]
    [References(typeof(Header))]
    public int HeaderChildId { get; set; }
  }
}

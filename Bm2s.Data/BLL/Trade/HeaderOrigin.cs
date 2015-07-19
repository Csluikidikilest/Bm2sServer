using ServiceStack.DataAnnotations;
using System;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderOrigin : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public DateTime Date { get; set; }

    [References(typeof(Header))]
    public int HeaderParentId { get; set; }

    [Ignore]
    public Header HeaderParent { get; set; }

    [References(typeof(Header))]
    public int HeaderChildId { get; set; }

    [Ignore]
    public Header HeaderChild { get; set; }
  }
}

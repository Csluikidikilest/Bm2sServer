using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class HeaderStatusStep : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [References(typeof(HeaderStatus))]
    public int HeaderStatusParentId { get; set; }

    [Ignore]
    public HeaderStatus HeaderStatusParent { get; set; }

    [References(typeof(HeaderStatus))]
    public int HeaderStatusChildId { get; set; }

    [Ignore]
    public HeaderStatus HeaderStatusChild { get; set; }
  }
}

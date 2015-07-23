using ServiceStack.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;

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

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.HeaderStatusParent = Datas.Instance.DataStorage.HeaderStatuses.FirstOrDefault<HeaderStatus>(item => item.Id == this.HeaderStatusParentId);
      this.HeaderStatusChild = Datas.Instance.DataStorage.HeaderStatuses.FirstOrDefault<HeaderStatus>(item => item.Id == this.HeaderStatusChildId);
    }
  }
}

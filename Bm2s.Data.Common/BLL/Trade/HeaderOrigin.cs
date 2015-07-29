using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
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

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.HeaderChild = Datas.Instance.DataStorage.Headers.FirstOrDefault<Header>(item => item.Id == this.HeaderChildId);
      this.HeaderParent = Datas.Instance.DataStorage.Headers.FirstOrDefault<Header>(item => item.Id == this.HeaderParentId);
    }
  }
}

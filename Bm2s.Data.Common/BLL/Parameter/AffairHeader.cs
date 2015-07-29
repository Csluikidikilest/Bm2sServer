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

    [Ignore]
    public Affair Affair { get; set; }

    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [Ignore]
    public Header Header { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Affair = Datas.Instance.DataStorage.Affairs.FirstOrDefault<Affair>(item => item.Id == this.AffairId);
      this.Header = Datas.Instance.DataStorage.Headers.FirstOrDefault<Header>(item => item.Id == this.HeaderId);
    }
  }
}

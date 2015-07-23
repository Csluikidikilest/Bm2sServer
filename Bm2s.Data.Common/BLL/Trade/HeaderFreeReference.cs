using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class HeaderFreeReference : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Reference { get; set; }

    [References(typeof(HeaderStatus))]
    public int HeaderStatusId { get; set; }

    [Ignore]
    public HeaderStatus HeaderStatus { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.HeaderStatus = Datas.Instance.DataStorage.HeaderStatuses.FirstOrDefault<HeaderStatus>(item => item.Id == this.HeaderStatusId);
    }
  }
}

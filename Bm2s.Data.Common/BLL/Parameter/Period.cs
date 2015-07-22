using Bm2s.Data.Common.Utils;
using ServiceStack.DataAnnotations;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Period : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public int Interval { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }

    [Ignore]
    public Unit Unit { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Unit = Datas.Instance.DataStorage.Units.FirstOrDefault<Unit>(item => item.Id == this.UnitId);
    }
  }
}

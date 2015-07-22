using Bm2s.Data.Common.Utils;
using ServiceStack.DataAnnotations;
using System;
using System.Linq;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class CountryCurrency : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Country))]
    public int CountryId { get; set; }

    [Ignore]
    public Country Country { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }

    [Ignore]
    public Unit Unit { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Country = Datas.Instance.DataStorage.Countries.FirstOrDefault<Country>(item => item.Id == this.CountryId);
      this.Unit = Datas.Instance.DataStorage.Units.FirstOrDefault<Unit>(item => item.Id == this.UnitId);
    }
  }
}

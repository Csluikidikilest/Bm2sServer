using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  [Alias("Cocu")]
  public class CountryCurrency : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [Alias("CounId")]
    [References(typeof(Country))]
    public int CountryId { get; set; }

    [Alias("UnitId")]
    [References(typeof(Unit))]
    public int UnitId { get; set; }
  }
}

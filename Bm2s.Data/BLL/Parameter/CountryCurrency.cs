using ServiceStack.DataAnnotations;
using System;

namespace Bm2s.Data.BLL.Parameter
{
  public class CountryCurrency : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; protected set; }

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
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class CountryCurrency
  {
    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [PrimaryKey]
    [References(typeof(Country))]
    public int CountryId { get; set; }

    [ForeignKey("CountryId")]
    public Country Country { get; set; }

    [PrimaryKey]
    [References(typeof(Unit))]
    public int UnitId { get; set; }

    [ForeignKey("UnitId")]
    public Unit Unit { get; set; }
  }
}

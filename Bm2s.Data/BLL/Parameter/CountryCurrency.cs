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
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Country))]
    public int CountryId { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }
  }
}

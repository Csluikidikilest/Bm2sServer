using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class Country
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Name { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Town))]
    public int TownId { get; set; }

    [ForeignKey("TownId")]
    public Town Town { get; set; }

    [InverseProperty("Country")]
    public List<Town> Towns { get; set; }

    [InverseProperty("Country")]
    public List<CountryCurrency> CountryCurrencies { get; set; }
  }
}

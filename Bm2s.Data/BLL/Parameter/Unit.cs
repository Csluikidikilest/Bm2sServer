using Bm2s.Data.BLL.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ServiceStack.OrmLite;

namespace Bm2s.Data.BLL.Parameter
{
  public class Unit
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

    public string Description { get; set; }

    public bool IsCurrency { get; set; }

    public bool IsPeriod { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [InverseProperty("Unit")]
    public List<Article.Article> Articles { get; set; }

    [InverseProperty("Unit")]
    public List<CountryCurrency> CountryCurrencies { get; set; }

    [InverseProperty("Unit")]
    public List<Period> Periods { get; set; }

    [InverseProperty("Child")]
    public List<UnitConversion> UnitConversionChildren { get; set; }

    [InverseProperty("Parent")]
    public List<UnitConversion> UnitConversionParents { get; set; }

    [InverseProperty("Unit")]
    public List<HeaderLine> HeaderLines { get; set; }

    [InverseProperty("Unit")]
    public List<Payment> Payments { get; set; }
  }
}

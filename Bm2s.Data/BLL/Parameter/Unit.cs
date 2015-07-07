using Bm2s.Data.BLL.Sell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class Unit
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    [Required] [StringLength(50)] public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCurrency { get; set; }
    public bool IsPeriod { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public List<Article.Article> Articles { get; set; }
    public List<CountryCurrency> CountryCurrencies { get; set; }
    public List<Period> Periods { get; set; }
    public List<UnitConversion> UnitConversionChildren { get; set; }
    public List<UnitConversion> UnitConversionParents { get; set; }
    public List<HeaderLine> HeaderLines { get; set; }
    public List<Payment> Payments { get; set; }
  }
}

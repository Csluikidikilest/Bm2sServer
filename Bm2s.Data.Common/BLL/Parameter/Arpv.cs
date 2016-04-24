using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Arpv : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public double Rate { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [StringLength(50)]
    public string AccountingEntry { get; set; }

    [References(typeof(Article.Arti))]
    public int ArtiId { get; set; }

    [References(typeof(Partner.Part))]
    public int PartId { get; set; }

    [References(typeof(Vat))]
    public int VatId { get; set; }
  }
}

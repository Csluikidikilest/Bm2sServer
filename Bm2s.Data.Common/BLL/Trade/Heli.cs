using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.BLL.Article;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class Heli : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public int LineNumber { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Designation { get; set; }

    public string Description { get; set; }

    [Default(0)]
    public double BuyPrice { get; set; }

    public double SellPrice { get; set; }

    [Default(1)]
    public int Quantity { get; set; }

    public string PreparationObservation { get; set; }

    public string DeliveryObservation { get; set; }

    public string SupplierCompanyName { get; set; }

    public double VatRate { get; set; }

    public bool IsPrintable { get; set; }

    [References(typeof(Article.Arti))]
    public int ArtiId { get; set; }

    [References(typeof(Arfa))]
    public int ArfaId { get; set; }

    [References(typeof(Arsf))]
    public int ArsfId { get; set; }

    [References(typeof(Bran))]
    public int BranId { get; set; }

    [References(typeof(Helt))]
    public int HeltId { get; set; }

    [References(typeof(Head))]
    public int HeadId { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }
  }
}

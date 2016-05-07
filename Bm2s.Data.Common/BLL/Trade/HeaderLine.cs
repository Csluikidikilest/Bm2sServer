using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.BLL.Article;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  [Alias("Heli")]
  public class HeaderLine : DataRow
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

    [Alias("ArtiId")]
    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }

    [Alias("ArfaId")]
    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [Alias("ArsfId")]
    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [Alias("BranId")]
    [References(typeof(Brand))]
    public int BrandId { get; set; }

    [Alias("HeltId")]
    [References(typeof(HeaderLineType))]
    public int HeaderLineTypeId { get; set; }

    [Alias("HeadId")]
    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [Alias("UnitId")]
    [References(typeof(Unit))]
    public int UnitId { get; set; }
  }
}

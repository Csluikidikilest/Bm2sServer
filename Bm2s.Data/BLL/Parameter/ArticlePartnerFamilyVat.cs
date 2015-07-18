using Bm2s.Data.BLL.Partner;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class ArticlePartnerFamilyVat : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; protected set; }

    [Default(0)]
    public double Rate { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [Required]
    [StringLength(50)]
    public string AccountingEntry { get; set; }

    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }

    [Ignore]
    public Article.Article Article { get; set; }

    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }

    [Ignore]
    public PartnerFamily PartnerFamily { get; set; }

    [References(typeof(Vat))]
    public int VatId { get; set; }

    [Ignore]
    public Vat Vat { get; set; }
  }
}

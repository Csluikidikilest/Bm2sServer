using System.ComponentModel.DataAnnotations.Schema;
using Bm2s.Data.BLL.Partner;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  [Table("ArticlePriceParnerFamily", Schema = "Article")]
  public class ArticlePriceParnerFamily
  {
    [Default(0)]
    public double? Price { get; set; }

    public bool AddPrice { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [References(typeof(Article))]
    public int ArticleId { get; set; }

    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }

    [ForeignKey("PartnerFamilyId")]
    public PartnerFamily PartnerFamily { get; set; }
  }
}
